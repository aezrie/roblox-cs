using System;
using Shared.Utils;
using Roblox;
using Roblox.Services;

namespace Server.Game;

public class GameLoop
{
    public GameLoop()
    {
        int result = MathUtils.Add(5, 10);
        Console.WriteLine("MathUtils result: " + result);
    }
}
