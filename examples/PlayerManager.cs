// PlayerManager.cs — roblox-cs class example
// Demonstrates: class emission, constructor, instance methods,
//               static methods, this -> self, events, null-conditional
using System;
using Roblox;
using Roblox.Services;
using Roblox.Instances;

public class PlayerManager
{
    private Players _players;
    private int _playerCount;

    public PlayerManager()
    {
        _players = Game.GetService<Players>();
        _playerCount = 0;
    }

    public void Initialize()
    {
        Console.WriteLine("PlayerManager initializing...");
        _players.PlayerAdded += this.OnPlayerAdded;
        _players.PlayerRemoving += this.OnPlayerRemoving;
    }

    private void OnPlayerAdded(Player player)
    {
        _playerCount = _playerCount + 1;
        Console.WriteLine("Player joined: " + player.Name);

        var character = player?.Character;
        var displayName = player.DisplayName ?? player.Name;

        if (character != null)
        {
            Console.WriteLine(displayName + " has a character");
        }
    }

    private void OnPlayerRemoving(Player player)
    {
        _playerCount = _playerCount - 1;
        Console.WriteLine("Player left: " + player.Name);
    }

    public static string GetVersion()
    {
        return "1.0.0";
    }
}
