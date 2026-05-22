using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class DragDetector : ClickDetector
{
    // Properties
    public object? ActivatedCursorIcon { get; set; } = null!;
    public string? ActivatedCursorIconContent { get; set; } = null!;
    public bool ApplyAtCenterOfMass { get; set; }
    public Vector3 Axis { get; set; }
    public CFrame DragFrame { get; set; }
    public object? DragStyle { get; set; } = null!;
    public bool Enabled { get; set; }
    public object? GamepadModeSwitchKeyCode { get; set; } = null!;
    public object? KeyboardModeSwitchKeyCode { get; set; } = null!;
    public float MaxDragAngle { get; set; }
    public Vector3 MaxDragTranslation { get; set; }
    public float MaxForce { get; set; }
    public float MaxTorque { get; set; }
    public float MinDragAngle { get; set; }
    public Vector3 MinDragTranslation { get; set; }
    public Vector3 Orientation { get; set; }
    public object? PermissionPolicy { get; set; } = null!;
    public Instance? ReferenceInstance { get; set; } = null!;
    public object? ResponseStyle { get; set; } = null!;
    public float Responsiveness { get; set; }
    public bool RunLocally { get; set; }
    public Vector3 SecondaryAxis { get; set; }
    public float TrackballRadialPullFactor { get; set; }
    public float TrackballRollFactor { get; set; }
    public object? VRSwitchKeyCode { get; set; } = null!;
    public Vector3 WorldAxis { get; set; }
    public Vector3 WorldSecondaryAxis { get; set; }

    // Methods
    public object AddConstraintFunction(int priority, Delegate? function) => null!;
    public CFrame GetReferenceFrame() => default!;
    public object RestartDrag() => null!;
    public object SetDragStyleFunction(Delegate? function) => null!;
    public object SetPermissionPolicyFunction(Delegate? function) => null!;

    // Events
    public event Action<object, Ray, CFrame, object, bool> DragContinue = null!;
    public event Action<object> DragEnd = null!;
    public event Action<object, Ray, CFrame, CFrame, object, object, bool> DragStart = null!;
}
