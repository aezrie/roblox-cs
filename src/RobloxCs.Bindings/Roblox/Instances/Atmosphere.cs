using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Atmosphere : Instance
{
    // Properties
    public Color3 Color { get; set; }
    public Color3 Decay { get; set; }
    public float Density { get; set; }
    public float Glare { get; set; }
    public float Haze { get; set; }
    public float Offset { get; set; }

}
