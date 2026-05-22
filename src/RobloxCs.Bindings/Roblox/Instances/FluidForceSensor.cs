using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class FluidForceSensor : SensorBase
{
    // Properties
    public Vector3 CenterOfPressure { get; }
    public Vector3 Force { get; }
    public Vector3 Torque { get; }

    // Methods
    public object[] EvaluateAsync(Vector3 linearVelocity, Vector3 angularVelocity, CFrame cframe) => default!;

}
