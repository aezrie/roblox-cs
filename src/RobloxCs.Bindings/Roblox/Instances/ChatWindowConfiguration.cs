using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ChatWindowConfiguration : TextChatConfigurations
{
    // Properties
    public Vector2 AbsolutePosition { get; }
    public Vector2 AbsoluteSize { get; }
    public Color3 BackgroundColor3 { get; set; }
    public double BackgroundTransparency { get; set; }
    public bool Enabled { get; set; }
    public object? FontFace { get; set; } = null!;
    public float HeightScale { get; set; }
    public object? HorizontalAlignment { get; set; } = null!;
    public Color3 TextColor3 { get; set; }
    public long TextSize { get; set; }
    public Color3 TextStrokeColor3 { get; set; }
    public double TextStrokeTransparency { get; set; }
    public object? VerticalAlignment { get; set; } = null!;
    public float WidthScale { get; set; }

    // Methods
    public object DeriveNewMessageProperties() => null!;

}
