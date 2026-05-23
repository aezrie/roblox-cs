# Project Overview: `roblox-cs`

## 1. What is `roblox-cs`?
`roblox-cs` is a C# to Luau transpiler designed for Roblox game development. Inspired by `roblox-ts`, it allows developers to write Roblox game logic in C# and compile it down to idiomatic, readable Luau code. It leverages the power of the Roslyn compiler API to parse C#, resolve types via the Semantic Model, and emit Luau using a custom Abstract Syntax Tree (AST).

## 2. Current State (Phase 1 Complete)
The foundational compiler pipeline is fully functional on .NET 9 / Arch Linux. 
- The Roslyn compilation environment successfully resolves core .NET types and custom Roblox binding stubs.
- The `Emitter` (a `CSharpSyntaxWalker`) traverses the C# AST, queries the `SemanticModel` for type information, and builds a Luau AST.
- The `Renderer` pretty-prints the Luau AST to a string.
- **Supported conversions:** Top-level statements, local variable declarations, `Game.GetService<T>()` -> `game:GetService("T")`, and `Console.WriteLine()` -> `print()`.
- **OOP Syntax:** Correctly emits `:` for Roblox method calls (e.g., `game:GetService()`) and `.` for properties/static methods via a `UseColon` flag in the AST.

## 3. Tech Stack & Architecture
- **Language:** C# (.NET 9)
- **Compiler API:** `Microsoft.CodeAnalysis.CSharp` (Roslyn)
- **Output Target:** Luau (Roblox)
- **Project Structure:**
  - `src/RobloxCs.Cli`: Console app entry point. Orchestrates the Roslyn compilation, loads references, and triggers the emitter.
  - `src/RobloxCs.Compiler`: Core library. Contains the `Emitter` (C# -> Luau AST walker), `Renderer` (AST -> String), and `LuauAst` definitions.
  - `src/RobloxCs.Bindings`: Fake C# classes representing the Roblox API. Used purely for IDE IntelliSense and Roslyn type resolution. Never run at runtime.

## 4. How the Pipeline Works
1. **Input:** C# source code string.
2. **Roslyn Compilation:** `CSharpCompilation.Create` parses the code. It references all DLLs in the current .NET runtime directory (crucial for Linux to avoid `System.Runtime` missing errors) and the `RobloxCs.Bindings.dll`.
3. **Emission:** The `Emitter` walks the C# SyntaxTree. When it needs to know *what* a node is (e.g., is this `GetService` a method on the `Game` class?), it asks the `SemanticModel`.
4. **Translation:** The `Emitter` constructs a tree of `LuaNode` records.
5. **Rendering:** The `Renderer` traverses the `LuaNode` tree, applying indentation and writing the final `.lua` string.

## 5. Key Design Decisions (Crucial for Agents)
- **File Extension:** Use `.cs`, NOT `.csx`. Standard C# tooling (OmniSharp, Rider, VS Code) relies on `.cs` for proper project-aware IntelliSense and source generators. `.csx` is treated as a scripting dialect and breaks IDE features.
- **Roblox API Mappings:** Instead of creating custom Roblox global functions that cause Roslyn metadata loading issues (e.g., custom `print()`), map built-in C# constructs to Luau. (e.g., `Console.WriteLine` -> `print()`).
- **Colon vs Dot:** Roblox OOP requires `:` for instance methods and `.` for properties/static methods. The Luau AST handles this via `LuaMemberAccessExpression(Expression, MemberName, UseColon)`.
- **Roslyn on Linux:** The CLI *must* load references by iterating `RuntimeEnvironment.GetRuntimeDirectory()` and loading all DLLs. Relying on `AppDomain.CurrentDomain` or `DependencyModel` will fail to resolve `System.Console` or `System.Runtime`.

---

# Implementation Plan

Here is the roadmap to build out the rest of the transpiler, ordered by priority and dependency.

## Phase 2: Core Game Loop Features
*Goal: Write a basic client-server script that compiles.*

- [x] **Events (`+=` / `-=`):** Map C# event subscriptions to `:Connect()` and `:Disconnect()`.
  - C#: `players.PlayerAdded += ...` -> Luau: `players.PlayerAdded:Connect(...)`
- [x] **Lambda to Function:** Translate C# `() => ...` or `(Player p) => ...` to `function() ... end` or `function(p) ... end`.
- [x] **Basic Types:** Ensure `int`, `float`, `string`, and `bool` literals map correctly to Luau numbers, strings, and booleans.
- [x] **Control Flow:** Implement visitors for `if/else if/else` and `return` statements.
- [x] **Loops:** Implement `foreach` over Roblox collections (maps to `for _, item in collection do`) and `while`.
- [x] **Method Calls on Instances:** Generalize method invocations on `[RobloxService]` types to automatically use the `:` syntax (e.g., `players.GetPlayers()` -> `players:GetPlayers()`). Properties/events correctly use `.`.

## Phase 3: Async/Await & Safe Navigation
*Goal: Eliminate Roblox coroutine boilerplate and nil-checking spam.*

- [x] **Null Conditional (`?.`):** Translate `player?.Character` to `player and player.Character`. Implement caching for repeated access (e.g., `a?.B?.C` -> `local _b = a and a.B; local _c = _b and _b.C`).
- [x] **Async/Await Stripping:** In Roblox, certain functions yield implicitly. Strip `await` from standard calls (e.g., `await remote.InvokeServerAsync()` -> `remote:InvokeServer()`).
- [x] **Async Event Handlers:** Introduce `ConnectAsync` in Bindings. The emitter must wrap these callbacks in `task.spawn(function() ... end)` so yields inside events don't lock the thread.
- [x] **Task.WhenAll:** Translate `Task.WhenAll(t1, t2)` to parallel `task.spawn` calls with a counter barrier.

## Phase 4: Type System Power - Structs & Pattern Matching
*Goal: Bring C#'s type safety to Roblox data structures.*

- [x] **Struct Emission:** Introduce `[RobloxStruct]`. Emit them as Luau tables with a `__index` metatable and a `:Clone()` method for value semantics.
- [x] **Struct Clone Inserter:** Create an emitter pass that inserts `:Clone()` on struct assignments (`a = b` -> `a = b:Clone()`), function arguments, and collection inserts.
- [x] **Records & `with` Expressions:** Translate `record struct` and `with` syntax into `Clone() + field mutation`. (e.g., `pos with { X = 5 }` -> `local _c = pos:Clone(); _c.X = 5; return _c`).
- [x] **Type Patterns (`switch`/`is`):** Map `case BasePart part:` to `if child:IsA("BasePart") then local part = child`.
- [x] **Property Patterns:** Map `case { Health: > 50 }:` to table index checks.

## Phase 5: LINQ & Advanced Emitter Passes
*Goal: Write declarative data transformation.*

- [x] **LINQ Fuser:** Detect `.Where().Select()` chains. Fuse them into a single efficient `for _, val in ipairs() do ... end` loop instead of emitting intermediate tables.
- [x] **LINQ Terminals:** Implement `Any`, `All`, `FirstOrDefault`, `ToDictionary` as short-circuiting loop emissions.
- [x] **Extension Methods:** Allow developers to write `instance.MyExtension()` and translate it to `Extensions.MyExtension(instance)`.

## Phase 6: Ecosystem & Developer Experience
*Goal: Make it production-ready and a joy to use.*

- [ ] **File I/O:** Read from actual `.cs` files instead of hardcoded strings.
- [ ] **Module System:** Map `using Shared.Types` to `local Types = require(script.Parent.Shared.Types)`. Emit `ModuleScript` returns for `static class` or `public class` constructs.
- [ ] **Rojo Integration:** Generate a `default.project.json` mapping `Server/`, `Client/`, and `Shared/` directories to the Roblox DataModel.
- [ ] **Source Generators:** Create a generator for `[RemoteEvent]` to auto-generate typed networking wrappers.
- [ ] **CLI Commands:** Implement `roblox-cs init`, `roblox-cs build`, and `roblox-cs watch` (using Roslyn's incremental compilation).
- [ ] **Native AOT:** Publish the CLI as a standalone single binary using .NET 9's Native AOT for instant startup times.


# ALWAYS COMMIT & PUBLISH TO GITHUB
# Use meaningful commit messages
# Always push to origin main after a major task /bugfix is complete.