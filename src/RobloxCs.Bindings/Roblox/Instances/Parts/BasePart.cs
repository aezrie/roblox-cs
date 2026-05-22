using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public abstract class BasePart : PVInstance
{
    // Properties
    public bool Anchored { get; set; }
    public Vector3 AssemblyAngularVelocity { get; set; }
    public Vector3 AssemblyCenterOfMass { get; }
    public Vector3 AssemblyLinearVelocity { get; set; }
    public float AssemblyMass { get; }
    public object? AssemblyRootPart { get; } = null!;
    public bool AudioCanCollide { get; set; }
    public object? BackSurface { get; set; } = null!;
    public object? BottomSurface { get; set; } = null!;
    public BrickColor BrickColor { get; set; }
    public CFrame CFrame { get; set; }
    public bool CanCollide { get; set; }
    public bool CanQuery { get; set; }
    public bool CanTouch { get; set; }
    public bool CastShadow { get; set; }
    public Vector3 CenterOfMass { get; }
    public string? CollisionGroup { get; set; } = null!;
    public Color3 Color { get; set; }
    public object? CurrentPhysicalProperties { get; } = null!;
    public object? CustomPhysicalProperties { get; set; } = null!;
    public bool EnableFluidForces { get; set; }
    public CFrame ExtentsCFrame { get; }
    public Vector3 ExtentsSize { get; }
    public object? FrontSurface { get; set; } = null!;
    public object? LeftSurface { get; set; } = null!;
    public bool Locked { get; set; }
    public float Mass { get; }
    public bool Massless { get; set; }
    public object? Material { get; set; } = null!;
    public string? MaterialVariant { get; set; } = null!;
    public CFrame PivotOffset { get; set; }
    public Vector3 Position { get; set; }
    public float Reflectance { get; set; }
    public int ResizeIncrement { get; }
    public Faces ResizeableFaces { get; }
    public object? RightSurface { get; set; } = null!;
    public int RootPriority { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Size { get; set; }
    public object? TopSurface { get; set; } = null!;
    public float Transparency { get; set; }

    // Methods
    public Vector3 AngularAccelerationToTorque(Vector3 angAcceleration, Vector3 angVelocity = default) => default!;
    public object ApplyAngularImpulse(Vector3 impulse) => null!;
    public object ApplyImpulse(Vector3 impulse) => null!;
    public object ApplyImpulseAtPosition(Vector3 impulse, Vector3 position) => null!;
    public bool CanCollideWith(object? part) => default!;
    public object[] CanSetNetworkOwnership() => default!;
    public Vector3 GetClosestPointOnSurface(Vector3 position) => default!;
    public object GetConnectedParts(bool recursive = false) => null!;
    public object GetJoints() => null!;
    public float GetMass() => default!;
    public Instance GetNetworkOwner() => null!;
    public bool GetNetworkOwnershipAuto() => default!;
    public object GetNoCollisionConstraints() => null!;
    public object GetTouchingParts() => null!;
    public Vector3 GetVelocityAtPosition(Vector3 position) => default!;
    public bool IsGrounded() => default!;
    public bool Resize(object? normalId, int deltaAmount) => default!;
    public object SetNetworkOwner(object? playerInstance = null) => null!;
    public object SetNetworkOwnershipAuto() => null!;
    public Vector3 TorqueToAngularAcceleration(Vector3 torque, Vector3 angVelocity = default) => default!;
    public Instance IntersectAsync(object? parts, object? collisionfidelity = null, object? renderFidelity = null) => null!;
    public Instance SubtractAsync(object? parts, object? collisionfidelity = null, object? renderFidelity = null) => null!;
    public Instance UnionAsync(object? parts, object? collisionfidelity = null, object? renderFidelity = null) => null!;

    // Events
    public event Action<object> TouchEnded = null!;
    public event Action<object> Touched = null!;
}
