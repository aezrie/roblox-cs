using System;

namespace Roblox.Instances;

public class Wire : Instance
{
    // Properties
    public bool Connected { get; }
    public Instance? SourceInstance { get; set; } = null!;
    public string? SourceName { get; set; } = null!;
    public Instance? TargetInstance { get; set; } = null!;
    public string? TargetName { get; set; } = null!;

}
