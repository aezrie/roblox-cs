using System;

namespace Roblox.Instances;

public class PartOperation : TriangleMeshPart
{
    // Properties
    public int TriangleCount { get; }
    public bool UsePartColor { get; set; }

    // Methods
    public object SubstituteGeometry(Instance? source) => null!;

}
