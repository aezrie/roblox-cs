using System;

namespace Roblox.Instances;

public class LineForce : Constraint
{
    // Properties
    public bool ApplyAtCenterOfMass { get; set; }
    public bool InverseSquareLaw { get; set; }
    public float Magnitude { get; set; }
    public float MaxForce { get; set; }
    public bool ReactionForceEnabled { get; set; }

}
