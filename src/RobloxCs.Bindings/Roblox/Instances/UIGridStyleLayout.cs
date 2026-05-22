using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UIGridStyleLayout : UILayout
{
    // Properties
    public Vector2 AbsoluteContentSize { get; }
    public object? FillDirection { get; set; } = null!;
    public object? HorizontalAlignment { get; set; } = null!;
    public object? SortOrder { get; set; } = null!;
    public object? VerticalAlignment { get; set; } = null!;

}
