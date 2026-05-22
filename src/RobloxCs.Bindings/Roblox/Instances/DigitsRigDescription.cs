using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class DigitsRigDescription : Instance
{
    // Properties
    public Instance? Index1 { get; set; } = null!;
    public CFrame Index1TposeAdjustment { get; set; }
    public Instance? Index2 { get; set; } = null!;
    public CFrame Index2TposeAdjustment { get; set; }
    public Instance? Index3 { get; set; } = null!;
    public CFrame Index3TposeAdjustment { get; set; }
    public Vector3 IndexRange { get; set; }
    public float IndexSize { get; set; }
    public Instance? Middle1 { get; set; } = null!;
    public CFrame Middle1TposeAdjustment { get; set; }
    public Instance? Middle2 { get; set; } = null!;
    public CFrame Middle2TposeAdjustment { get; set; }
    public Instance? Middle3 { get; set; } = null!;
    public CFrame Middle3TposeAdjustment { get; set; }
    public Vector3 MiddleRange { get; set; }
    public float MiddleSize { get; set; }
    public Instance? Pinky1 { get; set; } = null!;
    public CFrame Pinky1TposeAdjustment { get; set; }
    public Instance? Pinky2 { get; set; } = null!;
    public CFrame Pinky2TposeAdjustment { get; set; }
    public Instance? Pinky3 { get; set; } = null!;
    public CFrame Pinky3TposeAdjustment { get; set; }
    public Vector3 PinkyRange { get; set; }
    public float PinkySize { get; set; }
    public Instance? Ring1 { get; set; } = null!;
    public CFrame Ring1TposeAdjustment { get; set; }
    public Instance? Ring2 { get; set; } = null!;
    public CFrame Ring2TposeAdjustment { get; set; }
    public Instance? Ring3 { get; set; } = null!;
    public CFrame Ring3TposeAdjustment { get; set; }
    public Vector3 RingRange { get; set; }
    public float RingSize { get; set; }
    public object? Side { get; set; } = null!;
    public Instance? Thumb1 { get; set; } = null!;
    public CFrame Thumb1TposeAdjustment { get; set; }
    public Instance? Thumb2 { get; set; } = null!;
    public CFrame Thumb2TposeAdjustment { get; set; }
    public Instance? Thumb3 { get; set; } = null!;
    public CFrame Thumb3TposeAdjustment { get; set; }
    public Vector3 ThumbRange { get; set; }
    public float ThumbSize { get; set; }

    // Methods
    public Vector3 GetFingerControl(int fingerIndex) => default!;
    public Vector3 GetFingerTip(int fingerIndex) => default!;
    public object SetFingerControl(int fingerIndex, Vector3 control) => null!;
    public object SetFingerTip(int fingerIndex, Vector3 point) => null!;

}
