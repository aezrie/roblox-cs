using System;

namespace Roblox.Instances;

public class SwimController : ControllerBase
{
    // Properties
    public float AccelerationTime { get; set; }
    public float PitchMaxTorque { get; set; }
    public float PitchSpeedFactor { get; set; }
    public float RollMaxTorque { get; set; }
    public float RollSpeedFactor { get; set; }

}
