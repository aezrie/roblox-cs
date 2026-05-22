using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class BoxHandleAdornment : HandleAdornment
{
    // Properties
    public object? Shading { get; set; } = null!;
    public Vector3 Size { get; set; }

}
