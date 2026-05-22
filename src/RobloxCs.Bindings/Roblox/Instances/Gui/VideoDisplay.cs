using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class VideoDisplay : GuiObject
{
    // Properties
    public object? ResampleMode { get; set; } = null!;
    public object? ScaleType { get; set; } = null!;
    public UDim2 TileSize { get; set; }
    public Color3 VideoColor3 { get; set; }
    public Vector2 VideoRectOffset { get; set; }
    public Vector2 VideoRectSize { get; set; }
    public float VideoTransparency { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
