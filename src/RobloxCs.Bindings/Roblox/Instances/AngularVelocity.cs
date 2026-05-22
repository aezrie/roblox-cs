using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AngularVelocity : Constraint
{
    // Properties
    public Vector3 AngularVelocity_ { get; set; }
    public float MaxTorque { get; set; }
    public bool ReactionTorqueEnabled { get; set; }
    public object? RelativeTo { get; set; } = null!;

}
