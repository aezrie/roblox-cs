using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class BubbleChatConfiguration : TextChatConfigurations
{
    // Properties
    public string? AdorneeName { get; set; } = null!;
    public Color3 BackgroundColor3 { get; set; }
    public double BackgroundTransparency { get; set; }
    public float BubbleDuration { get; set; }
    public float BubblesSpacing { get; set; }
    public bool Enabled { get; set; }
    public object? FontFace { get; set; } = null!;
    public Vector3 LocalPlayerStudsOffset { get; set; }
    public float MaxBubbles { get; set; }
    public float MaxDistance { get; set; }
    public float MinimizeDistance { get; set; }
    public bool TailVisible { get; set; }
    public Color3 TextColor3 { get; set; }
    public long TextSize { get; set; }
    public float VerticalStudsOffset { get; set; }

}
