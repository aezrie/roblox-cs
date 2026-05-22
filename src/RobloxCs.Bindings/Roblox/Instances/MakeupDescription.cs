using System;

namespace Roblox.Instances;

public class MakeupDescription : Instance
{
    // Properties
    public long AssetId { get; set; }
    public Instance? Instance { get; set; } = null!;
    public object? MakeupType { get; set; } = null!;
    public int Order { get; set; }

    // Methods
    public Instance GetAppliedInstance() => null!;

}
