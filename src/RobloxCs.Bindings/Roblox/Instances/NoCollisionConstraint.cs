using System;

namespace Roblox.Instances;

public class NoCollisionConstraint : Instance
{
    // Properties
    public bool Enabled { get; set; }
    public object? Part0 { get; set; } = null!;
    public object? Part1 { get; set; } = null!;

}
