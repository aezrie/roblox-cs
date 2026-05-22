using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class HapticEffect : Instance
{
    // Properties
    public bool Looped { get; set; }
    public Vector3 Position { get; set; }
    public float Radius { get; set; }
    public object? Type { get; set; } = null!;

    // Methods
    public object Play() => null!;
    public object SetWaveformKeys(object[]? keys) => null!;
    public object Stop() => null!;

    // Events
    public event Action Ended = null!;
}
