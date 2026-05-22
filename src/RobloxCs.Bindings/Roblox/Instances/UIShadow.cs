using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UIShadow : UIComponent
{
    // Properties
    public UDim BlurRadius { get; set; }
    public Color3 Color { get; set; }
    public UDim2 Offset { get; set; }
    public UDim2 Spread { get; set; }
    public float Transparency { get; set; }
    public int ZIndex { get; set; }

}
