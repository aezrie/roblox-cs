using System;

namespace Roblox.Instances;

public class RemoteFunction : Instance
{
    // Methods
    public object[] InvokeClient(object? player, object[]? arguments) => default!;
    public object[] InvokeServer(object[]? arguments) => default!;

    // Callbacks
    public Func<object[], object[]>? OnClientInvoke { get; set; }
    public Func<object, object[], object[]>? OnServerInvoke { get; set; }

}
