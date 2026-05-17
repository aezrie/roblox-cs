using System;
using Roblox.Instances;
namespace Roblox.Services;
[RobloxService]
public class Players : Instance
{
    public Player LocalPlayer { get; set; } = null!;
    public event Action<Player> PlayerAdded = null!;
    public event Action<Player> PlayerRemoving = null!;
    public Player[] GetPlayers() => null!;
}
