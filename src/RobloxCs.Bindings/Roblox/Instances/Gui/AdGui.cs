using System;

namespace Roblox.Instances;

public class AdGui : SurfaceGuiBase
{
    // Properties
    public object? AdShape { get; set; } = null!;
    public bool EnableVideoAds { get; set; }
    public object? FallbackImage { get; set; } = null!;
    public object? Status { get; } = null!;

    // Callbacks
    public Func<System.Collections.Generic.Dictionary<string, object>, bool>? OnAdEvent { get; set; }

}
