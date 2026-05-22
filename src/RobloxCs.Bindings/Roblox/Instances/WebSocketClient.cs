using System;

namespace Roblox.Instances;

public class WebSocketClient : Instance
{
    // Properties
    public object? ConnectionState { get; } = null!;

    // Methods
    public object Close() => null!;
    public object Send(string? data) => null!;

    // Events
    public event Action Closed = null!;
    public event Action<string> MessageReceived = null!;
    public event Action Opened = null!;
}
