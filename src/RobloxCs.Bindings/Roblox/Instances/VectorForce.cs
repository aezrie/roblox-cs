using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class VectorForce : Constraint
{
    // Properties
    public bool ApplyAtCenterOfMass { get; set; }
    public Vector3 Force { get; set; }
    public object? RelativeTo { get; set; } = null!;

}
