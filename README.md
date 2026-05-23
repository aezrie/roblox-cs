# roblox-cs

`roblox-cs` is a powerful C# to Luau transpiler designed specifically for Roblox game development. Inspired by the success of `roblox-ts`, it enables developers to leverage C#'s robust type system, modern language features, and industry-standard tooling while targeting the Roblox platform.

## 🚀 Key Features

- **Roslyn-Powered**: Uses the official Microsoft.CodeAnalysis API for perfect C# parsing and semantic analysis.
- **Idiomatic Luau**: Generates readable, performant Luau code that follows Roblox best practices.
- **Type-Safe Bindings**: Full Roblox API stubs for complete IntelliSense and compile-time validation.
- **Modern C# Support**:
  - **Async/Await**: Automatically stripped and mapped to Luau's yielding functions.
  - **Null Conditionals**: `player?.Character?.Name` maps to safe `and` chains.
  - **Pattern Matching**: `is` and `switch` expressions map to Roblox `IsA()` checks.
  - **Structs**: C# structs (and `[RobloxStruct]` classes) gain value semantics in Luau via automatic cloning.
  - **Lambdas**: Full support for anonymous functions and async event handlers.

## 🛠️ Installation

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [Roblox Studio](https://www.roblox.com/create) (for testing)

### Clone & Build
```bash
git clone https://github.com/aezrie/roblox-cs.git
cd roblox-cs
dotnet build
```

## 📖 Quick Start

Write your Roblox logic in C#:

```csharp
using Roblox.Instances;
using Roblox.Services;

public class GameController
{
    public void Start()
    {
        var players = Game.GetService<Players>();
        
        players.PlayerAdded += async (player) => {
            print($"Welcome {player.Name}!");
            await Task.Delay(1000);
            SpawnPart(player);
        };
    }

    private void SpawnPart(Player player)
    {
        var part = new Part();
        part.Parent = Game.Workspace;
        part.Position = new Vector3(0, 10, 0);
    }
}
```

Transpile to Luau:
```bash
dotnet run --project src/RobloxCs.Cli/RobloxCs.Cli.csproj MyScript.cs
```

Output:
```lua
local GameController = {}
GameController.__index = GameController

function GameController.new()
    local self = setmetatable({}, GameController)
    return self
end

function GameController:Start()
    local players = game:GetService("Players")
    players.PlayerAdded:Connect(function(player)
        task.spawn(function()
            print(string.format("Welcome %s!", player.Name))
            task.wait(1)
            self:SpawnPart(player)
        end)
    end)
end

function GameController:SpawnPart(player)
    local part = Instance.new("Part")
    part.Parent = workspace
    part.Position = Vector3.new(0, 10, 0)
end

return GameController
```

## 🏗️ Project Structure

- `src/RobloxCs.Compiler`: The core transpilation logic (Emitter & Renderer).
- `src/RobloxCs.Bindings`: C# stubs for the Roblox API.
- `src/RobloxCs.Cli`: Command-line interface for the transpiler.
- `vscode-extension`: (In Progress) Language server support for VS Code.

## 📜 Roadmap

- [x] **Phase 1**: Foundational pipeline (Roslyn -> Luau AST).
- [x] **Phase 2**: Core game loop features (Events, Lambdas, OOP).
- [x] **Phase 3**: Async/Await & Safe Navigation.
- [x] **Phase 4**: Type System Power (Structs, Pattern Matching).
- [ ] **Phase 5**: LINQ & Advanced Emitter Passes.
- [ ] **Phase 6**: Ecosystem & Developer Experience (Rojo integration, File I/O).

## 🤝 Contributing

Contributions are welcome! Please check the [plan.md](plan.md) for current progress and upcoming tasks.

## 📄 License

This project is licensed under the MIT License.
