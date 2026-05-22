using System;
using Roblox.Instances;
using Roblox.Services;
using Roblox.Datatypes;

public class ApiTest
{
    public void RunTest()
    {
        // Test GetService
        var players = Roblox.Game.GetService<Players>();
        
        // Test Event
        players.PlayerAdded += (player) => {
            Console.WriteLine("Player joined!");
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
    }
}
