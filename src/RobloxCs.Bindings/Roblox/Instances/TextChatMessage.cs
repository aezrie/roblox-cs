using System;

namespace Roblox.Instances;

public class TextChatMessage : Instance
{
    // Properties
    public object? BubbleChatMessageProperties { get; set; } = null!;
    public object? ChatWindowMessageProperties { get; set; } = null!;
    public string? MessageId { get; set; } = null!;
    public string? Metadata { get; set; } = null!;
    public string? PrefixText { get; set; } = null!;
    public object? Status { get; set; } = null!;
    public string? Text { get; set; } = null!;
    public object? TextChannel { get; set; } = null!;
    public object? TextSource { get; set; } = null!;
    public object? Timestamp { get; set; } = null!;
    public string? Translation { get; set; } = null!;

}
