using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ControllerPartSensor : ControllerSensor
{
    // Properties
    public CFrame HitFrame { get; set; }
    public Vector3 HitNormal { get; set; }
    public float LadderSearchHeight { get; set; }
    public float LadderSearchOffset { get; set; }
    public float SearchDistance { get; set; }
    public object? SensedMaterial { get; set; } = null!;
    public object? SensedPart { get; set; } = null!;
    public object? SensorMode { get; set; } = null!;

}
