using System;

namespace Roblox.Instances;

public class AudioFilter : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public object? FilterType { get; set; } = null!;
    public float Frequency { get; set; }
    public float Gain { get; set; }
    public float Q { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public float GetGainAt(float frequency) => default!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
