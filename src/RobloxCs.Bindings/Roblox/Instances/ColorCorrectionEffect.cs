using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ColorCorrectionEffect : PostEffect
{
    // Properties
    public float Brightness { get; set; }
    public float Contrast { get; set; }
    public float Saturation { get; set; }
    public Color3 TintColor { get; set; }

}
