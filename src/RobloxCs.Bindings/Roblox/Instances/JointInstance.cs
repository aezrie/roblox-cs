using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class JointInstance : Instance
{
    // Properties
    public bool Active { get; }
    public CFrame C0 { get; set; }
    public CFrame C1 { get; set; }
    public bool Enabled { get; set; }
    public object? Part0 { get; set; } = null!;
    public object? Part1 { get; set; } = null!;

}
