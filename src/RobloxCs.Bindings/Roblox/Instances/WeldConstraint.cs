using System;

namespace Roblox.Instances;

public class WeldConstraint : Instance
{
    // Properties
    public bool Active { get; }
    public bool Enabled { get; set; }
    public object? Part0 { get; set; } = null!;
    public object? Part1 { get; set; } = null!;

}
