using System;

namespace Roblox.Instances;

public class AudioEcho : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public float DelayTime { get; set; }
    public float DryLevel { get; set; }
    public float Feedback { get; set; }
    public float RampTime { get; set; }
    public float WetLevel { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
