using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Path2D : GuiBase
{
    // Properties
    public bool Closed { get; set; }
    public Color3 Color3 { get; set; }
    public float Thickness { get; set; }
    public bool Visible { get; set; }
    public int ZIndex { get; set; }

    // Methods
    public Rect GetBoundingRect() => default!;
    public object GetControlPoint(int index) => null!;
    public object[] GetControlPoints() => default!;
    public float GetLength() => default!;
    public int GetMaxControlPoints() => default!;
    public UDim2 GetPositionOnCurve(float t) => default!;
    public UDim2 GetPositionOnCurveArcLength(float t) => default!;
    public Vector2 GetTangentOnCurve(float t) => default!;
    public Vector2 GetTangentOnCurveArcLength(float t) => default!;
    public object InsertControlPoint(int index, object? point) => null!;
    public object RemoveControlPoint(int index) => null!;
    public object SetControlPoints(object[]? controlPoints) => null!;
    public object UpdateControlPoint(int index, object? point) => null!;

    // Events
    public event Action ControlPointChanged = null!;
}
