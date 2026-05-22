using System;

namespace Roblox.Instances;

public class ScreenGui : LayerCollector
{
    // Properties
    public bool ClipToDeviceSafeArea { get; set; }
    public int DisplayOrder { get; set; }
    public bool IgnoreGuiInset { get; set; }
    public object? SafeAreaCompatibility { get; set; } = null!;
    public object? ScreenInsets { get; set; } = null!;

}
