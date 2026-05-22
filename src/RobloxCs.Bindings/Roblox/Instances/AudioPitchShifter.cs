using System;

namespace Roblox.Instances;

public class AudioPitchShifter : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public float Pitch { get; set; }
    public object? WindowSize { get; set; } = null!;

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
