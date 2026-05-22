using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UIDragDetector : UIComponent
{
    // Properties
    public object? ActivatedCursorIcon { get; set; } = null!;
    public string? ActivatedCursorIconContent { get; set; } = null!;
    public object? BoundingBehavior { get; set; } = null!;
    public object? BoundingUI { get; set; } = null!;
    public object? CursorIcon { get; set; } = null!;
    public string? CursorIconContent { get; set; } = null!;
    public Vector2 DragAxis { get; set; }
    public object? DragRelativity { get; set; } = null!;
    public float DragRotation { get; set; }
    public object? DragSpace { get; set; } = null!;
    public object? DragStyle { get; set; } = null!;
    public UDim2 DragUDim2 { get; set; }
    public bool Enabled { get; set; }
    public float MaxDragAngle { get; set; }
    public UDim2 MaxDragTranslation { get; set; }
    public float MinDragAngle { get; set; }
    public UDim2 MinDragTranslation { get; set; }
    public object? ReferenceUIInstance { get; set; } = null!;
    public object? ResponseStyle { get; set; } = null!;
    public UDim2 SelectionModeDragSpeed { get; set; }
    public float SelectionModeRotateSpeed { get; set; }
    public object? UIDragSpeedAxisMapping { get; set; } = null!;

    // Methods
    public object AddConstraintFunction(int priority, Delegate? function) => null!;
    public UDim2 GetReferencePosition() => default!;
    public float GetReferenceRotation() => default!;
    public object SetDragStyleFunction(Delegate? function) => null!;

    // Events
    public event Action<Vector2> DragContinue = null!;
    public event Action<Vector2> DragEnd = null!;
    public event Action<Vector2> DragStart = null!;
}
