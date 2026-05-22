using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class LinearVelocity : Constraint
{
    // Properties
    public object? ForceLimitMode { get; set; } = null!;
    public bool ForceLimitsEnabled { get; set; }
    public Vector3 LineDirection { get; set; }
    public float LineVelocity { get; set; }
    public Vector3 MaxAxesForce { get; set; }
    public float MaxForce { get; set; }
    public Vector2 MaxPlanarAxesForce { get; set; }
    public Vector2 PlaneVelocity { get; set; }
    public Vector3 PrimaryTangentAxis { get; set; }
    public bool ReactionForceEnabled { get; set; }
    public object? RelativeTo { get; set; } = null!;
    public Vector3 SecondaryTangentAxis { get; set; }
    public Vector3 VectorVelocity { get; set; }
    public object? VelocityConstraintMode { get; set; } = null!;

}
