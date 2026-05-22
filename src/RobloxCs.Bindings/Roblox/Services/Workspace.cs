using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class Workspace : WorldRoot
{
    // Properties
    public float AirDensity { get; set; }
    public float AirTurbulenceIntensity { get; set; }
    public bool AllowThirdPartySales { get; set; }
    public object? ClientAnimatorThrottling { get; set; } = null!;
    public object? CurrentCamera { get; set; } = null!;
    public double DistributedGameTime { get; set; }
    public Vector3 GlobalWind { get; set; }
    public float Gravity { get; set; }
    public Vector3 InsertPoint { get; set; }
    public object? Retargeting { get; set; } = null!;
    public object? Terrain { get; } = null!;

    // Methods
    public int GetNumAwakeParts() => default!;
    public int GetPhysicsThrottling() => default!;
    public double GetRealPhysicsFPS() => default!;
    public double GetServerTimeNow() => default!;
    public object JoinToOutsiders(object? objects, object? jointType) => null!;
    public bool PGSIsEnabled() => default!;
    public object UnjoinFromOutsiders(object? objects) => null!;

    // Events
    public event Action<object> PersistentLoaded = null!;
}
