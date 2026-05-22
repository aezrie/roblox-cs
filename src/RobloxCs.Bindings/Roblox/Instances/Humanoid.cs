using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Humanoid : Instance
{
    // Properties
    public bool AutoJumpEnabled { get; set; }
    public bool AutoRotate { get; set; }
    public bool AutomaticScalingEnabled { get; set; }
    public bool BreakJointsOnDeath { get; set; }
    public Vector3 CameraOffset { get; set; }
    public object? DisplayDistanceType { get; set; } = null!;
    public string? DisplayName { get; set; } = null!;
    public bool EvaluateStateMachine { get; set; }
    public object? FloorMaterial { get; } = null!;
    public float Health { get; set; }
    public float HealthDisplayDistance { get; set; }
    public object? HealthDisplayType { get; set; } = null!;
    public float HipHeight { get; set; }
    public bool Jump { get; set; }
    public float JumpHeight { get; set; }
    public float JumpPower { get; set; }
    public float MaxHealth { get; set; }
    public float MaxSlopeAngle { get; set; }
    public Vector3 MoveDirection { get; }
    public float NameDisplayDistance { get; set; }
    public object? NameOcclusion { get; set; } = null!;
    public bool PlatformStand { get; set; }
    public bool RequiresNeck { get; set; }
    public object? RigType { get; set; } = null!;
    public object? RootPart { get; } = null!;
    public object? SeatPart { get; } = null!;
    public bool Sit { get; set; }
    public Vector3 TargetPoint { get; set; }
    public bool UseJumpPower { get; set; }
    public float WalkSpeed { get; set; }
    public object? WalkToPart { get; set; } = null!;
    public Vector3 WalkToPoint { get; set; }

    // Methods
    public object AddAccessory(Instance? accessory) => null!;
    public object BuildRigFromAttachments() => null!;
    public object ChangeState(object? state = null) => null!;
    public object EquipTool(Instance? tool) => null!;
    public object[] GetAccessories() => default!;
    public object GetAppliedDescription() => null!;
    public object GetBodyPartR15(Instance? part) => null!;
    public object GetLimb(Instance? part) => null!;
    public Vector3 GetMoveVelocity() => default!;
    public Vector3 GetRelativeVelocityAtFloor() => default!;
    public object GetState() => null!;
    public bool GetStateEnabled(object? state) => default!;
    public object Move(Vector3 moveDirection, bool relativeToCamera = false) => null!;
    public object MoveTo(Vector3 location, Instance? part = null) => null!;
    public object RemoveAccessories() => null!;
    public bool ReplaceBodyPartR15(object? bodyPart, object? part) => default!;
    public object SetStateEnabled(object? state, bool enabled) => null!;
    public object TakeDamage(float amount) => null!;
    public object UnequipTools() => null!;
    public object ApplyDescriptionAsync(object? humanoidDescription, object? assetTypeVerification = null) => null!;
    public object ApplyDescriptionResetAsync(object? humanoidDescription, object? assetTypeVerification = null) => null!;
    public bool PlayEmoteAsync(string? emoteName) => default!;

    // Events
    public event Action<object> ApplyDescriptionFinished = null!;
    public event Action<float> Climbing = null!;
    public event Action Died = null!;
    public event Action<bool> FallingDown = null!;
    public event Action<bool> FreeFalling = null!;
    public event Action<bool> GettingUp = null!;
    public event Action<float> HealthChanged = null!;
    public event Action<bool> Jumping = null!;
    public event Action<bool> MoveToFinished = null!;
    public event Action<bool> PlatformStanding = null!;
    public event Action<bool> Ragdoll = null!;
    public event Action<float> Running = null!;
    public event Action<bool, object> Seated = null!;
    public event Action<object, object> StateChanged = null!;
    public event Action<object, bool> StateEnabledChanged = null!;
    public event Action<bool> Strafing = null!;
    public event Action<float> Swimming = null!;
    public event Action<object, object> Touched = null!;
}
