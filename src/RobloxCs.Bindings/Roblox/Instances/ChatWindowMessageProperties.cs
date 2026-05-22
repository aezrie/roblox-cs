using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ChatWindowMessageProperties : TextChatMessageProperties
{
    // Properties
    public object? FontFace { get; set; } = null!;
    public object? PrefixTextProperties { get; set; } = null!;
    public Color3 TextColor3 { get; set; }
    public int TextSize { get; set; }
    public Color3 TextStrokeColor3 { get; set; }
    public double TextStrokeTransparency { get; set; }

}
