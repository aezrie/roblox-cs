using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class NetworkServer : NetworkPeer
{
    // Methods
    public string EncryptStringForPlayerId(string? toEncrypt, long playerId) => default!;

}
