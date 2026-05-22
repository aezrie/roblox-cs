using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AlignOrientation : Constraint
{
    // Properties
    public object? AlignType { get; set; } = null!;
    public CFrame CFrame { get; set; }
    public Vector3 LookAtPosition { get; set; }
    public float MaxAngularVelocity { get; set; }
    public float MaxTorque { get; set; }
    public object? Mode { get; set; } = null!;
    public Vector3 PrimaryAxis { get; set; }
    public bool PrimaryAxisOnly { get; set; }
    public bool ReactionTorqueEnabled { get; set; }
    public float Responsiveness { get; set; }
    public bool RigidityEnabled { get; set; }
    public Vector3 SecondaryAxis { get; set; }

}
