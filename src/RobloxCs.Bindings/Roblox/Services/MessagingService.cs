using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class MessagingService : Instance
{
    // Methods
    public object PublishAsync(string? topic, object? message) => null!;
    public object SubscribeAsync(string? topic, Delegate? callback) => null!;

}
