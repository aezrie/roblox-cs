using System;

namespace Roblox.Instances;

public class AudioRecorder : Instance
{
    // Properties
    public double TimeLength { get; }

    // Methods
    public object Clear() => null!;
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;
    public string GetTemporaryContent() => default!;
    public object Stop() => null!;
    public bool CanRecordAsync() => default!;
    public object GetUnrecordableInstancesAsync() => null!;
    public object RecordAsync() => null!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
