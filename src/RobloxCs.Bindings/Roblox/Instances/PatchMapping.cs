using System;

namespace Roblox.Instances;

public class PatchMapping : Instance
{
    // Properties
    public bool FlattenTree { get; set; }
    public string? PatchId { get; set; } = null!;
    public string? TargetPath { get; set; } = null!;

}
