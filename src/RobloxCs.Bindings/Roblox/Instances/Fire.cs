using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Fire : Instance
{
    // Properties
    public Color3 Color { get; set; }
    public bool Enabled { get; set; }
    public float Heat { get; set; }
    public Color3 SecondaryColor { get; set; }
    public float Size { get; set; }
    public float TimeScale { get; set; }

}
