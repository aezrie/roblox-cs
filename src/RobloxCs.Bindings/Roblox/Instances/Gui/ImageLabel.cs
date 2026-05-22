using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ImageLabel : GuiLabel
{
    // Properties
    public object? Image { get; set; } = null!;
    public Color3 ImageColor3 { get; set; }
    public string? ImageContent { get; set; } = null!;
    public Vector2 ImageRectOffset { get; set; }
    public Vector2 ImageRectSize { get; set; }
    public float ImageTransparency { get; set; }
    public bool IsLoaded { get; }
    public object? ResampleMode { get; set; } = null!;
    public object? ScaleType { get; set; } = null!;
    public Rect SliceCenter { get; set; }
    public float SliceScale { get; set; }
    public UDim2 TileSize { get; set; }

}
