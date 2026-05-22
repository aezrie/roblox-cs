using System;

namespace Roblox.Instances;

public class AudioEmitter : Instance
{
    // Properties
    public bool AcousticSimulationEnabled { get; set; }
    public string? AudioInteractionGroup { get; set; } = null!;

    // Methods
    public System.Collections.Generic.Dictionary<string, object> GetAngleAttenuation() => default!;
    public float GetAudibilityFor(object? listener) => default!;
    public object GetConnectedWires(string? pin) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetDistanceAttenuation() => default!;
    public object[] GetInputPins() => default!;
    public object GetInteractingListeners() => null!;
    public object[] GetOutputPins() => default!;
    public object SetAngleAttenuation(System.Collections.Generic.Dictionary<string, object> curve) => null!;
    public object SetDistanceAttenuation(System.Collections.Generic.Dictionary<string, object> curve) => null!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
