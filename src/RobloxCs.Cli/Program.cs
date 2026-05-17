using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RobloxCs.Compiler;
using System.IO;
using System.Runtime.InteropServices;

// 1. The "User's" Roblox C# Code — Phase 2 test harness
string userCode = """
using System;
using Roblox;
using Roblox.Services;
using Roblox.Instances;

// GetService + print
Players players = Game.GetService<Players>();
Console.WriteLine("Server started!");

// Event subscription with lambda body
players.PlayerAdded += (Player player) =>
{
    Console.WriteLine("Player joined!");

    // if / else
    if (player != null)
    {
        Console.WriteLine("Player is valid");
    }
    else
    {
        Console.WriteLine("Player was null somehow");
    }
};

// Binary operations and Loops
int count = 0;
while (count < 10)
{
    count = count + 1;
}

foreach (var p in players.GetPlayers())
{
    Console.WriteLine(p.Name);
}
""";

// 2. Setup Roslyn references
var references = new List<MetadataReference>();

// A. Load ALL core .NET runtime DLLs (Console, Runtime, Collections, etc.)
var runtimeDir = RuntimeEnvironment.GetRuntimeDirectory();
foreach (var dll in Directory.GetFiles(runtimeDir, "*.dll"))
{
    references.Add(MetadataReference.CreateFromFile(dll));
}

// B. Load our custom Bindings assembly
var bindingsPath = typeof(Roblox.Services.Players).Assembly.Location;
if (!string.IsNullOrEmpty(bindingsPath) && File.Exists(bindingsPath))
{
    references.Add(MetadataReference.CreateFromFile(bindingsPath));
    Console.WriteLine($"[DEBUG] Loading Bindings from: {bindingsPath}");
}
else
{
    Console.WriteLine("❌ ERROR: Could not find RobloxCs.Bindings.dll!");
    return;
}

// 3. Create the Roslyn Compilation
var compilation = CSharpCompilation.Create(
    "RobloxCsUserProject",
    syntaxTrees: new[] { CSharpSyntaxTree.ParseText(userCode) },
    references: references,
    options: new CSharpCompilationOptions(OutputKind.ConsoleApplication)
);

// 4. Check for C# compilation errors
var diagnostics = compilation.GetDiagnostics().Where(d => d.Severity == DiagnosticSeverity.Error).ToList();
if (diagnostics.Any())
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("❌ C# Compilation Errors:");
    foreach (var diag in diagnostics)
        Console.WriteLine($"  {diag}");
    Console.ResetColor();
    return;
}

// 5. Run our Emitter
var tree = compilation.SyntaxTrees.First();
var semanticModel = compilation.GetSemanticModel(tree);

var emitter = new Emitter(semanticModel);
var luauAst = emitter.Emit();

// 6. Render the AST to a Luau string
var renderer = new Renderer();
string luauOutput = renderer.Render(luauAst);

Console.WriteLine("\n--- Generated Luau ---");
Console.WriteLine(luauOutput);
