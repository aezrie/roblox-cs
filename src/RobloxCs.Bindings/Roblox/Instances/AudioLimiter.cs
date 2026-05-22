using System;

namespace Roblox.Instances;

public class AudioLimiter : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public float MaxLevel { get; set; }
    public float Release { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
