using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Highlight : Instance
{
    // Properties
    public Instance? Adornee { get; set; } = null!;
    public object? DepthMode { get; set; } = null!;
    public bool Enabled { get; set; }
    public Color3 FillColor { get; set; }
    public float FillTransparency { get; set; }
    public Color3 OutlineColor { get; set; }
    public float OutlineTransparency { get; set; }

}
