using System;

namespace Roblox.Instances;

public class UIFlexItem : UIComponent
{
    // Properties
    public object? FlexMode { get; set; } = null!;
    public float GrowRatio { get; set; }
    public object? ItemLineAlignment { get; set; } = null!;
    public float ShrinkRatio { get; set; }

}
