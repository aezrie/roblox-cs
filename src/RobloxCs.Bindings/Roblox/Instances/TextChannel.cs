using System;

namespace Roblox.Instances;

public class TextChannel : Instance
{
    // Properties
    public object? DirectChatRequester { get; } = null!;

    // Methods
    public object DisplaySystemMessage(string? systemMessage, string? metadata = null) => null!;
    public object SetDirectChatRequester(object? requester) => null!;
    public object[] AddUserAsync(long userId) => default!;
    public object SendAsync(string? message, string? metadata = null) => null!;

    // Callbacks
    public Func<object, object[]>? OnIncomingMessage { get; set; }
    public Func<object, object, object[]>? ShouldDeliverCallback { get; set; }

    // Events
    public event Action<object> MessageReceived = null!;
}
