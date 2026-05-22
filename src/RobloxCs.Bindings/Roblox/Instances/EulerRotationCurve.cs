using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class EulerRotationCurve : Instance
{
    // Properties
    public object? RotationOrder { get; set; } = null!;

    // Methods
    public object[] GetAnglesAtTime(float time) => default!;
    public CFrame GetRotationAtTime(float time) => default!;
    public object X() => null!;
    public object Y() => null!;
    public object Z() => null!;

}
