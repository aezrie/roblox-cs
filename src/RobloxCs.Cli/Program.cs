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

// ── Directory mode ──────────────────────────────────────────────────────────
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

    int ok = 0, fail = 0;
    foreach (var csFile in csFiles)
    {
        var outFile = Path.ChangeExtension(csFile, ".lua");
        int result = CompileFile(csFile, outFile);
        if (result == 0) ok++; else fail++;
    }

    Console.WriteLine();
    Console.ForegroundColor = fail == 0 ? ConsoleColor.Green : ConsoleColor.Red;
    Console.WriteLine($"[roblox-cs] Done — {ok} succeeded, {fail} failed.");
    Console.ResetColor();
    return fail > 0 ? 1 : 0;
}

// ── Single-file mode ────────────────────────────────────────────────────────
if (!File.Exists(inputArg))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"❌ File or directory not found: {inputArg}");
    Console.ResetColor();
    return 1;
}

int oFlag = Array.IndexOf(args, "-o");
string singleOut = oFlag >= 0 && oFlag + 1 < args.Length
    ? args[oFlag + 1]
    : Path.ChangeExtension(Path.GetFullPath(inputArg), ".lua");

return CompileFile(inputArg, singleOut);

// ── Shared compile helper ───────────────────────────────────────────────────
int CompileFile(string inputPath, string outputPath)
{

// ── Read source ─────────────────────────────────────────────────────────────
string userCode = File.ReadAllText(inputPath);

// ── Setup Roslyn references ─────────────────────────────────────────────────
var references = new List<MetadataReference>();

// Load ALL core .NET runtime DLLs (Console, Runtime, Collections, etc.)
var runtimeDir = RuntimeEnvironment.GetRuntimeDirectory();
foreach (var dll in Directory.GetFiles(runtimeDir, "*.dll"))
    references.Add(MetadataReference.CreateFromFile(dll));

// Load our custom Bindings assembly
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

// ── Roslyn Compilation ──────────────────────────────────────────────────────
var syntaxTree = CSharpSyntaxTree.ParseText(userCode);
bool hasTopLevelStatements = syntaxTree.GetRoot()
    .DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.GlobalStatementSyntax>().Any();
var outputKind = hasTopLevelStatements
    ? OutputKind.ConsoleApplication
    : OutputKind.DynamicallyLinkedLibrary;

var compilation = CSharpCompilation.Create(
    "RobloxCsUserProject",
    syntaxTrees: new[] { syntaxTree },
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
        Console.WriteLine($"  {diag}");
    Console.ResetColor();
    return 1;
}

// ── Emit ────────────────────────────────────────────────────────────────────
var tree = compilation.SyntaxTrees.First();
var semanticModel = compilation.GetSemanticModel(tree);

var emitter = new Emitter(semanticModel);
var luauAst = emitter.Emit();

// ── Render ──────────────────────────────────────────────────────────────────
var renderer = new Renderer();
string luauOutput = renderer.Render(luauAst);

// ── Write output ─────────────────────────────────────────────────────────────
Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);
File.WriteAllText(outputPath, luauOutput);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"[roblox-cs] ✅ Written: {outputPath}");
Console.ResetColor();

Console.WriteLine();
Console.WriteLine("--- Generated Luau ---");
Console.WriteLine(luauOutput);

return 0;
} // end CompileFile
