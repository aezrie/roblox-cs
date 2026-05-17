using System;
using Roblox.Instances;

namespace Roblox.Services;

[RobloxService]
public class Players
{
    public event Action<Player> PlayerAdded = null!;
}
