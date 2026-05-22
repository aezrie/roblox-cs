using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class HumanoidRigDescription : Instance
{
    // Properties
    public Instance? Chest { get; set; } = null!;
    public Vector3 ChestRangeMax { get; set; }
    public Vector3 ChestRangeMin { get; set; }
    public float ChestSize { get; set; }
    public CFrame ChestTposeAdjustment { get; set; }
    public Instance? HeadBase { get; set; } = null!;
    public Vector3 HeadBaseRangeMax { get; set; }
    public Vector3 HeadBaseRangeMin { get; set; }
    public float HeadBaseSize { get; set; }
    public CFrame HeadBaseTposeAdjustment { get; set; }
    public Instance? LeftAnkle { get; set; } = null!;
    public Vector3 LeftAnkleRangeMax { get; set; }
    public Vector3 LeftAnkleRangeMin { get; set; }
    public float LeftAnkleSize { get; set; }
    public CFrame LeftAnkleTposeAdjustment { get; set; }
    public Instance? LeftClavicle { get; set; } = null!;
    public Vector3 LeftClavicleRangeMax { get; set; }
    public Vector3 LeftClavicleRangeMin { get; set; }
    public float LeftClavicleSize { get; set; }
    public CFrame LeftClavicleTposeAdjustment { get; set; }
    public Instance? LeftElbow { get; set; } = null!;
    public Vector3 LeftElbowRangeMax { get; set; }
    public Vector3 LeftElbowRangeMin { get; set; }
    public float LeftElbowSize { get; set; }
    public CFrame LeftElbowTposeAdjustment { get; set; }
    public Instance? LeftHip { get; set; } = null!;
    public Vector3 LeftHipRangeMax { get; set; }
    public Vector3 LeftHipRangeMin { get; set; }
    public float LeftHipSize { get; set; }
    public CFrame LeftHipTposeAdjustment { get; set; }
    public Instance? LeftKnee { get; set; } = null!;
    public Vector3 LeftKneeRangeMax { get; set; }
    public Vector3 LeftKneeRangeMin { get; set; }
    public float LeftKneeSize { get; set; }
    public CFrame LeftKneeTposeAdjustment { get; set; }
    public Instance? LeftShoulder { get; set; } = null!;
    public Vector3 LeftShoulderRangeMax { get; set; }
    public Vector3 LeftShoulderRangeMin { get; set; }
    public float LeftShoulderSize { get; set; }
    public CFrame LeftShoulderTposeAdjustment { get; set; }
    public Instance? LeftToeBase { get; set; } = null!;
    public Vector3 LeftToeBaseRangeMax { get; set; }
    public Vector3 LeftToeBaseRangeMin { get; set; }
    public float LeftToeBaseSize { get; set; }
    public CFrame LeftToeBaseTposeAdjustment { get; set; }
    public Instance? LeftWrist { get; set; } = null!;
    public Vector3 LeftWristRangeMax { get; set; }
    public Vector3 LeftWristRangeMin { get; set; }
    public float LeftWristSize { get; set; }
    public CFrame LeftWristTposeAdjustment { get; set; }
    public Instance? Neck { get; set; } = null!;
    public Vector3 NeckRangeMax { get; set; }
    public Vector3 NeckRangeMin { get; set; }
    public float NeckSize { get; set; }
    public CFrame NeckTposeAdjustment { get; set; }
    public Instance? RightAnkle { get; set; } = null!;
    public Vector3 RightAnkleRangeMax { get; set; }
    public Vector3 RightAnkleRangeMin { get; set; }
    public float RightAnkleSize { get; set; }
    public CFrame RightAnkleTposeAdjustment { get; set; }
    public Instance? RightClavicle { get; set; } = null!;
    public Vector3 RightClavicleRangeMax { get; set; }
    public Vector3 RightClavicleRangeMin { get; set; }
    public float RightClavicleSize { get; set; }
    public CFrame RightClavicleTposeAdjustment { get; set; }
    public Instance? RightElbow { get; set; } = null!;
    public Vector3 RightElbowRangeMax { get; set; }
    public Vector3 RightElbowRangeMin { get; set; }
    public float RightElbowSize { get; set; }
    public CFrame RightElbowTposeAdjustment { get; set; }
    public Instance? RightHip { get; set; } = null!;
    public Vector3 RightHipRangeMax { get; set; }
    public Vector3 RightHipRangeMin { get; set; }
    public float RightHipSize { get; set; }
    public CFrame RightHipTposeAdjustment { get; set; }
    public Instance? RightKnee { get; set; } = null!;
    public Vector3 RightKneeRangeMax { get; set; }
    public Vector3 RightKneeRangeMin { get; set; }
    public float RightKneeSize { get; set; }
    public CFrame RightKneeTposeAdjustment { get; set; }
    public Instance? RightShoulder { get; set; } = null!;
    public Vector3 RightShoulderRangeMax { get; set; }
    public Vector3 RightShoulderRangeMin { get; set; }
    public float RightShoulderSize { get; set; }
    public CFrame RightShoulderTposeAdjustment { get; set; }
    public Instance? RightToeBase { get; set; } = null!;
    public Vector3 RightToeBaseRangeMax { get; set; }
    public Vector3 RightToeBaseRangeMin { get; set; }
    public float RightToeBaseSize { get; set; }
    public CFrame RightToeBaseTposeAdjustment { get; set; }
    public Instance? RightWrist { get; set; } = null!;
    public Vector3 RightWristRangeMax { get; set; }
    public Vector3 RightWristRangeMin { get; set; }
    public float RightWristSize { get; set; }
    public CFrame RightWristTposeAdjustment { get; set; }
    public Instance? Root { get; set; } = null!;
    public Vector3 RootRangeMax { get; set; }
    public Vector3 RootRangeMin { get; set; }
    public float RootSize { get; set; }
    public CFrame RootTposeAdjustment { get; set; }
    public Instance? Spine { get; set; } = null!;
    public Vector3 SpineRangeMax { get; set; }
    public Vector3 SpineRangeMin { get; set; }
    public float SpineSize { get; set; }
    public CFrame SpineTposeAdjustment { get; set; }
    public Instance? Waist { get; set; } = null!;
    public Vector3 WaistRangeMax { get; set; }
    public Vector3 WaistRangeMin { get; set; }
    public float WaistSize { get; set; }
    public CFrame WaistTposeAdjustment { get; set; }

    // Methods
    public Instance GetJointFromName(string? name) => null!;
    public object[] GetJointNames() => default!;
    public object[] GetR15JointNames() => default!;
    public object[] GetR6JointNames() => default!;

}
