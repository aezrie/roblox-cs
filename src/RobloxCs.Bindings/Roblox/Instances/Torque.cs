using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Torque : Constraint
{
    // Properties
    public object? RelativeTo { get; set; } = null!;
    public Vector3 Torque_ { get; set; }

}
