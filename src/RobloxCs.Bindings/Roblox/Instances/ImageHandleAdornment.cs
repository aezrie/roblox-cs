using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ImageHandleAdornment : HandleAdornment
{
    // Properties
    public object? Image { get; set; } = null!;
    public Vector2 Size { get; set; }

}
