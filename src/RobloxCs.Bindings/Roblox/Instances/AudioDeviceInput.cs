using System;

namespace Roblox.Instances;

public class AudioDeviceInput : Instance
{
    // Properties
    public object? AccessType { get; set; } = null!;
    public bool Muted { get; set; }
    public object? Player { get; set; } = null!;
    public float Volume { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;
    public object[] GetUserIdAccessList() => default!;
    public object SetUserIdAccessList(object[]? userIds) => null!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
