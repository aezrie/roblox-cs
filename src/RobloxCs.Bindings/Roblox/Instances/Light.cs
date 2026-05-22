using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Light : Instance
{
    // Properties
    public float Brightness { get; set; }
    public Color3 Color { get; set; }
    public bool Enabled { get; set; }
    public bool Shadows { get; set; }

}
