using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ChatInputBarConfiguration : TextChatConfigurations
{
    // Properties
    public Vector2 AbsolutePosition { get; }
    public Vector2 AbsoluteSize { get; }
    public bool AutocompleteEnabled { get; set; }
    public Color3 BackgroundColor3 { get; set; }
    public double BackgroundTransparency { get; set; }
    public bool Enabled { get; set; }
    public object? FontFace { get; set; } = null!;
    public bool IsFocused { get; }
    public object? KeyboardKeyCode { get; set; } = null!;
    public Color3 PlaceholderColor3 { get; set; }
    public object? TargetTextChannel { get; set; } = null!;
    public object? TextBox { get; set; } = null!;
    public Color3 TextColor3 { get; set; }
    public long TextSize { get; set; }
    public Color3 TextStrokeColor3 { get; set; }
    public double TextStrokeTransparency { get; set; }

}
