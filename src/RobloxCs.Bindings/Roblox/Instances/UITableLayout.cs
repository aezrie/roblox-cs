using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UITableLayout : UIGridStyleLayout
{
    // Properties
    public bool FillEmptySpaceColumns { get; set; }
    public bool FillEmptySpaceRows { get; set; }
    public object? MajorAxis { get; set; } = null!;
    public UDim2 Padding { get; set; }

}
