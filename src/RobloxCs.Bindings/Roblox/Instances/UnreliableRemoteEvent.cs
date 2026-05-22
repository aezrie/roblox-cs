using System;

namespace Roblox.Instances;

public class UnreliableRemoteEvent : BaseRemoteEvent
{
    // Methods
    public object FireAllClients(object[]? arguments) => null!;
    public object FireClient(object? player, object[]? arguments) => null!;
    public object FireServer(object[]? arguments) => null!;

    // Events
    public event Action<object[]> OnClientEvent = null!;
    public event Action<object, object[]> OnServerEvent = null!;
}
