// PlayerService.cs — roblox-cs example
// Demonstrates: GetService, events, lambdas, if/else, foreach, ?., ??

using System;
using Roblox;
using Roblox.Services;
using Roblox.Instances;

Players players = Game.GetService<Players>();

Console.WriteLine("Server started!");

// Listen for new players joining
players.PlayerAdded += (Player player) =>
{
    Console.WriteLine("Player joined: " + player.Name);

    // Null-conditional: only access Character if player is non-null
    var character = player?.Character;

    // Null-coalescing: fall back gracefully
    var displayName = player.DisplayName ?? player.Name;

    Console.WriteLine("Display name: " + displayName);

    if (character != null)
    {
        Console.WriteLine("Character exists");
    }
    else
    {
        Console.WriteLine("Waiting for character...");
    }
};

// Listen for players leaving
players.PlayerRemoving += (Player player) =>
{
    Console.WriteLine("Player left: " + player.Name);
};

// List all currently connected players
foreach (var p in players.GetPlayers())
{
    Console.WriteLine("Online: " + p.Name);
}
