using System;

namespace Roblox.Instances;

public class DataStoreInfo : Instance
{
    // Properties
    public long CreatedTime { get; }
    public string? DataStoreName { get; } = null!;
    public long UpdatedTime { get; }

}
