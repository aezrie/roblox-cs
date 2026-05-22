using System;

namespace Roblox.Instances;

public class RopeConstraint : Constraint
{
    // Properties
    public float CurrentDistance { get; }
    public float Length { get; set; }
    public float Restitution { get; set; }
    public float Thickness { get; set; }
    public bool WinchEnabled { get; set; }
    public float WinchForce { get; set; }
    public float WinchResponsiveness { get; set; }
    public float WinchSpeed { get; set; }
    public float WinchTarget { get; set; }

}
