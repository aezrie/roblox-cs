using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class TextChatService : Instance
{
    // Methods
    public object DisplayBubble(Instance? partOrCharacter, string? message) => null!;
    public bool CanUserChatAsync(long userId) => default!;
    public bool CanUsersChatAsync(long userIdFrom, long userIdTo) => default!;
    public object[] CanUsersDirectChatAsync(long requesterUserId, object[]? userIds) => default!;
    public object[] GetChatGroupsAsync(object? players) => default!;

    // Callbacks
    public Func<object, Instance, object[]>? OnBubbleAdded { get; set; }
    public Func<object, object[]>? OnChatWindowAdded { get; set; }
    public Func<object, object[]>? OnIncomingMessage { get; set; }

    // Events
    public event Action<Instance, object> BubbleDisplayed = null!;
    public event Action<object> MessageReceived = null!;
    public event Action<object> SendingMessage = null!;
}
