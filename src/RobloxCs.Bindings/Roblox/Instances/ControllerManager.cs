using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ControllerManager : Instance
{
    // Properties
    public object? ActiveController { get; set; } = null!;
    public float BaseMoveSpeed { get; set; }
    public float BaseTurnSpeed { get; set; }
    public object? ClimbSensor { get; set; } = null!;
    public Vector3 FacingDirection { get; set; }
    public object? GroundSensor { get; set; } = null!;
    public Vector3 MovingDirection { get; set; }
    public object? RootPart { get; set; } = null!;
    public Vector3 UpDirection { get; set; }

}
