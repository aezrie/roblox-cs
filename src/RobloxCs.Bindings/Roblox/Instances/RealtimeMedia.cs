using System;

namespace Roblox.Instances;

public class RealtimeMedia : Instance
{
    // Properties
    public bool IsConnected { get; }

    // Methods
    public object Disconnect() => null!;
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;
    public bool SendMessage(string? message, bool binary) => default!;
    public bool ConnectAsync(string? serverUrl, System.Collections.Generic.Dictionary<string, object> connectParams = null) => default!;

    // Events
    public event Action<string, bool> OnMessage = null!;
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
