using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ViewportFrame : GuiObject
{
    // Properties
    public Color3 Ambient { get; set; }
    public object? CurrentCamera { get; set; } = null!;
    public Color3 ImageColor3 { get; set; }
    public float ImageTransparency { get; set; }
    public Color3 LightColor { get; set; }
    public Vector3 LightDirection { get; set; }

}
