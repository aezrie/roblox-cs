using System;

namespace Roblox.Instances;

public class CompositeValueCurve : Instance
{
    // Properties
    public object? CurveType { get; set; } = null!;

    // Methods
    public object GetComponentCurves() => null!;
    public object GetValueAtTime(float time) => null!;

}
