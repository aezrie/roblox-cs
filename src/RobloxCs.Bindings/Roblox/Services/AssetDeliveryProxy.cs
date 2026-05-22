using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class AssetDeliveryProxy : Instance
{
    // Properties
    public string? Interface { get; set; } = null!;
    public int Port { get; set; }
    public bool StartServer { get; set; }

}
