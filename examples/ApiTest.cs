using System;
using Roblox.Instances;
using Roblox.Services;
using Roblox.Datatypes;

public class ApiTest
{
    public async System.Threading.Tasks.Task RunTest()
    {
        // Test GetService
        var players = Roblox.Game.GetService<Players>();
        
        // Test Event
        players.PlayerAdded += async (player) => {
            Console.WriteLine("Player joined!");
            await DoSomethingAsync();
        };

        // Test Method Call (Colon)
        var allPlayers = players.GetPlayers();

        // Test Property Access (Dot)
        Console.WriteLine("Max players: " + players.MaxPlayers);

        // Test Instance Creation
        var part = new Part();
        part.Name = "TestPart";
        part.Position = new Vector3(0, 10, 0);
        part.Parent = Roblox.Game.Workspace;

        // Test Null Conditional
        var name = part?.Name;
        var nested = part?.Parent?.Name;
        Console.WriteLine("Part name: " + name);

        // Test Async/Await (Stripping)
        await DoSomethingAsync();
    }

    private async System.Threading.Tasks.Task DoSomethingAsync()
    {
        Console.WriteLine("Doing something async...");
    }
}
