using System;

namespace Roblox.Instances;

public class PathfindingLink : Instance
{
    // Properties
    public object? Attachment0 { get; set; } = null!;
    public object? Attachment1 { get; set; } = null!;
    public bool IsBidirectional { get; set; }
    public string? Label { get; set; } = null!;

}
