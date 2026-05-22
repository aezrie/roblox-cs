using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UIGridLayout : UIGridStyleLayout
{
    // Properties
    public Vector2 AbsoluteCellCount { get; }
    public Vector2 AbsoluteCellSize { get; }
    public UDim2 CellPadding { get; set; }
    public UDim2 CellSize { get; set; }
    public int FillDirectionMaxCells { get; set; }
    public object? StartCorner { get; set; } = null!;

}
