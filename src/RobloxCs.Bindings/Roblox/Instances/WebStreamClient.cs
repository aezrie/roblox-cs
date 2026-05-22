using System;

namespace Roblox.Instances;

public class WebStreamClient : Object
{
    // Properties
    public object? ConnectionState { get; } = null!;

    // Methods
    public object Close() => null!;
    public object Send(string? data) => null!;

    // Events
    public event Action Closed = null!;
    public event Action<int, string> Error = null!;
    public event Action<string> MessageReceived = null!;
    public event Action<int, string> Opened = null!;
}
