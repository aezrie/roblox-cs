using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class BubbleChatMessageProperties : TextChatMessageProperties
{
    // Properties
    public Color3 BackgroundColor3 { get; set; }
    public double BackgroundTransparency { get; set; }
    public object? FontFace { get; set; } = null!;
    public bool TailVisible { get; set; }
    public Color3 TextColor3 { get; set; }
    public long TextSize { get; set; }

}
