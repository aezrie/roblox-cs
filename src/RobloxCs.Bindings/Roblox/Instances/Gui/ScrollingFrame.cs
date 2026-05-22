using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ScrollingFrame : GuiObject
{
    // Properties
    public Vector2 AbsoluteCanvasSize { get; }
    public Vector2 AbsoluteWindowSize { get; }
    public object? AutomaticCanvasSize { get; set; } = null!;
    public object? BottomImage { get; set; } = null!;
    public string? BottomImageContent { get; set; } = null!;
    public Vector2 CanvasPosition { get; set; }
    public UDim2 CanvasSize { get; set; }
    public object? ElasticBehavior { get; set; } = null!;
    public object? HorizontalScrollBarInset { get; set; } = null!;
    public object? MidImage { get; set; } = null!;
    public string? MidImageContent { get; set; } = null!;
    public Color3 ScrollBarImageColor3 { get; set; }
    public float ScrollBarImageTransparency { get; set; }
    public int ScrollBarThickness { get; set; }
    public object? ScrollingDirection { get; set; } = null!;
    public bool ScrollingEnabled { get; set; }
    public object? TopImage { get; set; } = null!;
    public string? TopImageContent { get; set; } = null!;
    public object? VerticalScrollBarInset { get; set; } = null!;
    public object? VerticalScrollBarPosition { get; set; } = null!;

    // Methods
    public Vector2 GetScrollVelocity() => default!;
    public object ResetScrollVelocity() => null!;

}
