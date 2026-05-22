using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Smoke : Instance
{
    // Properties
    public Color3 Color { get; set; }
    public bool Enabled { get; set; }
    public float Opacity { get; set; }
    public float RiseVelocity { get; set; }
    public float Size { get; set; }
    public float TimeScale { get; set; }

}
