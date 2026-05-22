using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AtmosphereSensor : SensorBase
{
    // Properties
    public float AirDensity { get; }
    public Vector3 RelativeWindVelocity { get; }

}
