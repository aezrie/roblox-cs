using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class SurfaceGui : SurfaceGuiBase
{
    // Properties
    public bool AlwaysOnTop { get; set; }
    public float Brightness { get; set; }
    public Vector2 CanvasSize { get; set; }
    public bool ClipsDescendants { get; set; }
    public float LightInfluence { get; set; }
    public float MaxDistance { get; set; }
    public float PixelsPerStud { get; set; }
    public object? SizingMode { get; set; } = null!;
    public float ToolPunchThroughDistance { get; set; }
    public float ZOffset { get; set; }

}
