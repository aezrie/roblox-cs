using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UIListLayout : UIGridStyleLayout
{
    // Properties
    public object? HorizontalFlex { get; set; } = null!;
    public object? ItemLineAlignment { get; set; } = null!;
    public UDim Padding { get; set; }
    public object? VerticalFlex { get; set; } = null!;
    public bool Wraps { get; set; }

}
