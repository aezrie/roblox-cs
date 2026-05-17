using System;

namespace Roblox.Instances;

public class RemoteEvent : Instance
{
    // Server-side: fires when a client calls FireServer()
    public event Action<Player, object[]> OnServerEvent = null!;

    public event Action<object[]> OnClientEvent = null!;

    // Client -> Server
    public void FireServer(params object[] args) { }

    // Server -> specific client
    public void FireClient(Player player, params object[] args) { }

    // Server -> all clients
    public void FireAllClients(params object[] args) { }
}
