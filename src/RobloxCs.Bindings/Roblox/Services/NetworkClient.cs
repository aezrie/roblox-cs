using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class NetworkClient : NetworkPeer
{
    // Events
    public event Action<string, Instance> ConnectionAccepted = null!;
    public event Action<string, int> ConnectionFailed = null!;
}
