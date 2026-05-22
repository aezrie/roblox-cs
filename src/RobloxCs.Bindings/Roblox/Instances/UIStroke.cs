using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UIStroke : UIComponent
{
    // Properties
    public object? ApplyStrokeMode { get; set; } = null!;
    public UDim BorderOffset { get; set; }
    public object? BorderStrokePosition { get; set; } = null!;
    public Color3 Color { get; set; }
    public bool Enabled { get; set; }
    public object? LineJoinMode { get; set; } = null!;
    public object? StrokeSizingMode { get; set; } = null!;
    public float Thickness { get; set; }
    public float Transparency { get; set; }
    public int ZIndex { get; set; }

}
