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
    Console.WriteLine("  roblox-cs <input.cs>              Compile and write <input.lua> next to input");
    Console.WriteLine("  roblox-cs <input.cs> -o <out.lua> Compile and write to specified output path");
    Console.ResetColor();
    return 1;
}

string inputPath = args[0];
if (!File.Exists(inputPath))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"❌ File not found: {inputPath}");
    Console.ResetColor();
    return 1;
}

// Determine output path
string outputPath;
int oFlag = Array.IndexOf(args, "-o");
if (oFlag >= 0 && oFlag + 1 < args.Length)
{
    outputPath = args[oFlag + 1];
}
else
{
    outputPath = Path.ChangeExtension(Path.GetFullPath(inputPath), ".lua");
}

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"[roblox-cs] Compiling: {Path.GetFullPath(inputPath)}");
Console.ResetColor();

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
var compilation = CSharpCompilation.Create(
    "RobloxCsUserProject",
    syntaxTrees: new[] { CSharpSyntaxTree.ParseText(userCode) },
    references: references,
    options: new CSharpCompilationOptions(OutputKind.ConsoleApplication)
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

// Also print to stdout so it's easy to inspect
Console.WriteLine();
Console.WriteLine("--- Generated Luau ---");
Console.WriteLine(luauOutput);

return 0;
