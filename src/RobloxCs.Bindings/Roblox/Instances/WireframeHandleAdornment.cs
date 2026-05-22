using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class WireframeHandleAdornment : HandleAdornment
{
    // Properties
    public Vector3 Scale { get; set; }
    public float Thickness { get; set; }

    // Methods
    public object AddLine(Vector3 from, Vector3 to) => null!;
    public object AddLines(object[]? points) => null!;
    public object AddPath(object[]? points, bool loop) => null!;
    public object AddText(Vector3 point, string? text, int size = default) => null!;
    public object Clear() => null!;

}
