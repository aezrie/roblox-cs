using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AlignPosition : Constraint
{
    // Properties
    public bool ApplyAtCenterOfMass { get; set; }
    public object? ForceLimitMode { get; set; } = null!;
    public object? ForceRelativeTo { get; set; } = null!;
    public Vector3 MaxAxesForce { get; set; }
    public float MaxForce { get; set; }
    public float MaxVelocity { get; set; }
    public object? Mode { get; set; } = null!;
    public Vector3 Position { get; set; }
    public bool ReactionForceEnabled { get; set; }
    public float Responsiveness { get; set; }
    public bool RigidityEnabled { get; set; }

}
