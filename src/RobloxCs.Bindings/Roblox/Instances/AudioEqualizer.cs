using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AudioEqualizer : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public float HighGain { get; set; }
    public float LowGain { get; set; }
    public float MidGain { get; set; }
    public NumberRange MidRange { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
