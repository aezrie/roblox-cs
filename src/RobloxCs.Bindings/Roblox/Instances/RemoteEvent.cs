using System;
using Roblox.Instances;
namespace Roblox.Instances;
public class RemoteEvent : Instance
{
    public event Action<Player, object[]> OnServerEvent = null!;
    public event Action<object[]> OnClientEvent = null!;
    public void FireServer(params object[] args) { }
    public void FireClient(Player player, params object[] args) { }
    public void FireAllClients(params object[] args) { }
}
