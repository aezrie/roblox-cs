using System;

namespace Roblox.Instances;

public class TeleportOptions : Instance
{
    // Properties
    public string? ReservedServerAccessCode { get; set; } = null!;
    public string? ServerInstanceId { get; set; } = null!;
    public bool ShouldReserveServer { get; set; }

    // Methods
    public object GetTeleportData() => null!;
    public object SetTeleportData(object? teleportData) => null!;

}
