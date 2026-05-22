using System;

namespace Roblox.Instances;

public class AudioCompressor : Instance
{
    // Properties
    public float Attack { get; set; }
    public bool Bypass { get; set; }
    public float MakeupGain { get; set; }
    public float Ratio { get; set; }
    public float Release { get; set; }
    public float Threshold { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
