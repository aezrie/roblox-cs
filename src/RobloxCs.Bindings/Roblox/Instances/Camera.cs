using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Camera : PVInstance
{
    // Properties
    public CFrame CFrame { get; set; }
    public Instance? CameraSubject { get; set; } = null!;
    public object? CameraType { get; set; } = null!;
    public float DiagonalFieldOfView { get; set; }
    public float FieldOfView { get; set; }
    public object? FieldOfViewMode { get; set; } = null!;
    public CFrame Focus { get; set; }
    public bool HeadLocked { get; set; }
    public float HeadScale { get; set; }
    public float MaxAxisFieldOfView { get; set; }
    public float NearPlaneZ { get; }
    public bool VRTiltAndRollEnabled { get; set; }
    public Vector2 ViewportSize { get; }

    // Methods
    public object GetPartsObscuringTarget(object[]? castPoints, object? ignoreList) => null!;
    public CFrame GetRenderCFrame() => default!;
    public float GetRoll() => default!;
    public Ray ScreenPointToRay(float x, float y, float depth = 0) => default!;
    public object SetRoll(float rollAngle) => null!;
    public Ray ViewportPointToRay(float x, float y, float depth = 0) => default!;
    public object[] WorldToScreenPoint(Vector3 worldPoint) => default!;
    public object[] WorldToViewportPoint(Vector3 worldPoint) => default!;
    public object ZoomToExtents(CFrame boundingBoxCFrame, Vector3 boundingBoxSize) => null!;

    // Events
    public event Action InterpolationFinished = null!;
}
