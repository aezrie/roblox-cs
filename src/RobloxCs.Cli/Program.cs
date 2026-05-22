using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RobloxCs.Compiler;
using System.IO;
using System.Runtime.InteropServices;

// ── Argument parsing ────────────────────────────────────────────────────────
if (args.Length == 0)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("roblox-cs — C# to Luau transpiler");
    Console.WriteLine();
    Console.WriteLine("Usage:");
    Console.WriteLine("  roblox-cs <input.cs>              Compile one file, write <input.lua> next to it");
    Console.WriteLine("  roblox-cs <input.cs> -o <out.lua> Compile one file to a specific output");
    Console.WriteLine("  roblox-cs <directory/>            Compile every .cs file in the directory");
    Console.ResetColor();
    return 1;
}

string inputArg = args[0];

// ── Setup input files ───────────────────────────────────────────────────────
var filesToCompile = new List<(string InputPath, string OutputPath)>();

if (Directory.Exists(inputArg))
{
    var csFiles = Directory.GetFiles(inputArg, "*.cs", SearchOption.AllDirectories);
    if (csFiles.Length == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[roblox-cs] No .cs files found in: {inputArg}");
        Console.ResetColor();
        return 0;
    }
    foreach (var csFile in csFiles)
    {
        filesToCompile.Add((csFile, Path.ChangeExtension(csFile, ".lua")));
    }
}
else if (File.Exists(inputArg))
{
    int oFlag = Array.IndexOf(args, "-o");
    string singleOut = oFlag >= 0 && oFlag + 1 < args.Length
        ? args[oFlag + 1]
        : Path.ChangeExtension(Path.GetFullPath(inputArg), ".lua");
    filesToCompile.Add((inputArg, singleOut));
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"❌ File or directory not found: {inputArg}");
    Console.ResetColor();
    return 1;
}

// ── Setup Roslyn references ─────────────────────────────────────────────────
var references = new List<MetadataReference>();

var runtimeDir = RuntimeEnvironment.GetRuntimeDirectory();
foreach (var dll in Directory.GetFiles(runtimeDir, "*.dll"))
    references.Add(MetadataReference.CreateFromFile(dll));

var bindingsPath = typeof(Roblox.Services.Players).Assembly.Location;
if (!string.IsNullOrEmpty(bindingsPath) && File.Exists(bindingsPath))
{
    references.Add(MetadataReference.CreateFromFile(bindingsPath));
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("❌ ERROR: Could not find RobloxCs.Bindings.dll!");
    Console.ResetColor();
    return 1;
}

// ── Read and Parse all files ────────────────────────────────────────────────
var syntaxTrees = new List<SyntaxTree>();
bool hasAnyTopLevelStatements = false;

foreach (var file in filesToCompile)
{
    string userCode = File.ReadAllText(file.InputPath);
    var syntaxTree = CSharpSyntaxTree.ParseText(userCode, path: file.InputPath);
    syntaxTrees.Add(syntaxTree);

    if (syntaxTree.GetRoot().DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax>().Any())
    {
        hasAnyTopLevelStatements = true;
    }
}

var outputKind = hasAnyTopLevelStatements
    ? OutputKind.ConsoleApplication
    : OutputKind.DynamicallyLinkedLibrary;

// ── Roslyn Compilation ──────────────────────────────────────────────────────
var compilation = CSharpCompilation.Create(
    "RobloxCsUserProject",
    syntaxTrees: syntaxTrees,
    references: references,
    options: new CSharpCompilationOptions(outputKind)
);

// Check for C# compilation errors
var diagnostics = compilation.GetDiagnostics()
    .Where(d => d.Severity == DiagnosticSeverity.Error)
    .ToList();

if (diagnostics.Any())
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("❌ C# Compilation Errors:");
    foreach (var diag in diagnostics)
    {
        var lineSpan = diag.Location.GetLineSpan();
        var fileName = Path.GetFileName(lineSpan.Path);
        Console.WriteLine($"  [{fileName}] {diag}");
    }
    Console.ResetColor();
    return 1;
}

// ── Emit & Render ───────────────────────────────────────────────────────────
int ok = 0, fail = 0;

for (int i = 0; i < syntaxTrees.Count; i++)
{
    var tree = syntaxTrees[i];
    var outFile = filesToCompile[i].OutputPath;

    try
    {
        var semanticModel = compilation.GetSemanticModel(tree);
        var emitter = new Emitter(semanticModel);
        var luauAst = emitter.Emit();

        var renderer = new Renderer();
        string luauOutput = renderer.Render(luauAst);

        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outFile))!);
        File.WriteAllText(outFile, luauOutput);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[roblox-cs] ✅ Written: {outFile}");
        Console.ResetColor();
        ok++;
        
        if (filesToCompile.Count == 1)
        {
            Console.WriteLine();
            Console.WriteLine("--- Generated Luau ---");
            Console.WriteLine(luauOutput);
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[roblox-cs] ❌ Failed to compile {filesToCompile[i].InputPath}:\n{ex}");
        Console.ResetColor();
        fail++;
    }
}

if (filesToCompile.Count > 1)
{
    Console.WriteLine();
    Console.ForegroundColor = fail == 0 ? ConsoleColor.Green : ConsoleColor.Red;
    Console.WriteLine($"[roblox-cs] Done — {ok} succeeded, {fail} failed.");
    Console.ResetColor();
}

return fail > 0 ? 1 : 0;
