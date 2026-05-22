using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class Chat : Instance
{
    // Properties
    public bool BubbleChatEnabled { get; set; }

    // Methods
    public object Chat_(Instance? partOrCharacter, string? message, object? color = null) => null!;
    public object[] InvokeChatCallback(object? callbackType, object[]? callbackArguments) => default!;
    public object RegisterChatCallback(object? callbackType, Delegate? callbackFunction) => null!;
    public object SetBubbleChatSettings(object? settings) => null!;
    public bool CanUserChatAsync(long userId) => default!;
    public bool CanUsersChatAsync(long userIdFrom, long userIdTo) => default!;
    public string FilterStringAsync(string? stringToFilter, object? playerFrom, object? playerTo) => default!;
    public string FilterStringForBroadcast(string? stringToFilter, object? playerFrom) => default!;

    // Events
    public event Action<Instance, string, object> Chatted = null!;
}
