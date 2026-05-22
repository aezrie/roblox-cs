using System;

namespace Roblox.Instances;

public class GetTextBoundsParams : Instance
{
    // Properties
    public object? Font { get; set; } = null!;
    public bool RichText { get; set; }
    public float Size { get; set; }
    public string? Text { get; set; } = null!;
    public float Width { get; set; }

}
