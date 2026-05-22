using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class NotificationService : Instance
{
    // Events
    public event Action<string, object, string> Roblox17sConnectionChanged = null!;
    public event Action<object> Roblox17sEventReceived = null!;
}
