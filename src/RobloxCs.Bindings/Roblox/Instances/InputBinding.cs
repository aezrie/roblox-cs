using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class InputBinding : Instance
{
    // Properties
    public object? Backward { get; set; } = null!;
    public bool ClampMagnitudeToOne { get; set; }
    public object? Down { get; set; } = null!;
    public object? Forward { get; set; } = null!;
    public object? KeyCode { get; set; } = null!;
    public object? Left { get; set; } = null!;
    public int PointerIndex { get; set; }
    public float PressedThreshold { get; set; }
    public object? PrimaryModifier { get; set; } = null!;
    public float ReleasedThreshold { get; set; }
    public float ResponseCurve { get; set; }
    public object? Right { get; set; } = null!;
    public float Scale { get; set; }
    public object? SecondaryModifier { get; set; } = null!;
    public object? UIButton { get; set; } = null!;
    public object? UIModifier { get; set; } = null!;
    public object? Up { get; set; } = null!;
    public Vector2 Vector2Scale { get; set; }
    public Vector3 Vector3Scale { get; set; }

}
