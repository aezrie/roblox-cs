using System;

namespace Roblox.Instances;

public class DataStoreKeyInfo : Instance
{
    // Properties
    public long CreatedTime { get; }
    public long UpdatedTime { get; }
    public string? Version { get; } = null!;

    // Methods
    public System.Collections.Generic.Dictionary<string, object> GetMetadata() => default!;
    public object[] GetUserIds() => default!;

}
