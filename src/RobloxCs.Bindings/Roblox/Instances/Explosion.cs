using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Explosion : Instance
{
    // Properties
    public float BlastPressure { get; set; }
    public float BlastRadius { get; set; }
    public float DestroyJointRadiusPercent { get; set; }
    public object? ExplosionType { get; set; } = null!;
    public Vector3 Position { get; set; }
    public float TimeScale { get; set; }
    public bool Visible { get; set; }

    // Events
    public event Action<object, float> Hit = null!;
}
