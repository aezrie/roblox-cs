using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class NetworkSettings : Instance
{
    // Properties
    public double IncomingReplicationLag { get; set; }
    public bool PrintJoinSizeBreakdown { get; set; }
    public bool PrintPhysicsErrors { get; set; }
    public bool PrintStreamInstanceQuota { get; set; }
    public bool RandomizeJoinInstanceOrder { get; set; }
    public bool RenderStreamedRegions { get; set; }
    public bool ShowActiveAnimationAsset { get; set; }

}
