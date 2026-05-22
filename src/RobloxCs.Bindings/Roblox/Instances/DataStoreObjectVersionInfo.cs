using System;

namespace Roblox.Instances;

public class DataStoreObjectVersionInfo : Instance
{
    // Properties
    public long CreatedTime { get; }
    public bool IsDeleted { get; }
    public string? Version { get; } = null!;

}
