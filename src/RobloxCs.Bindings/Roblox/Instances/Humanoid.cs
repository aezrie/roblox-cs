using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Humanoid : Instance
{
    // Movement
    public float WalkSpeed { get; set; }
    public float JumpHeight { get; set; }
    public float JumpPower { get; set; }
    public bool UseJumpPower { get; set; }
    public bool Jump { get; set; }
    public bool AutoRotate { get; set; }
    public bool AutoJumpEnabled { get; set; }
    public float MaxSlopeAngle { get; set; }
    public Vector3 MoveDirection { get; }
    public Vector3 CameraOffset { get; set; }
    public Vector3 WalkToPoint { get; set; }
    public BasePart? WalkToPart { get; set; }

    // Health
    public float Health { get; set; }
    public float MaxHealth { get; set; }
    public float HipHeight { get; set; }

    // State
    public bool Sit { get; set; }
    public bool PlatformStand { get; set; }
    public bool EvaluateStateMachine { get; set; }
    public bool BreakJointsOnDeath { get; set; }
    public bool RequiresNeck { get; set; }
    public bool AutomaticScalingEnabled { get; set; }
    public BasePart? RootPart { get; }
    public BasePart? SeatPart { get; }

    // Display
    public string DisplayName { get; set; } = null!;
    public float NameDisplayDistance { get; set; }
    public float HealthDisplayDistance { get; set; }

    // Methods
    public void TakeDamage(float amount) { }
    public void Move(Vector3 moveDirection, bool relativeToCamera = false) { }
    public void MoveTo(Vector3 location, Instance? part = null) { }
    public void ChangeState(int state) { }
    public int GetState() => default;
    public bool GetStateEnabled(int state) => default;
    public void SetStateEnabled(int state, bool enabled) { }
    public void BuildRigFromAttachments() { }
    public void EquipTool(Instance tool) { }
    public void UnequipTools() { }
    public void AddAccessory(Instance accessory) { }
    public void RemoveAccessories() { }
    public Instance[] GetAccessories() => null!;
    public Vector3 GetMoveVelocity() => default;
    public Vector3 GetRelativeVelocityAtFloor() => default;
    public float GetScale() => default;
    public void ScaleTo(float scale) { }

    // Events
    public event Action Died = null!;
    public event Action<float> HealthChanged = null!;
    public event Action<float> Running = null!;
    public event Action<float> Swimming = null!;
    public event Action<float> Climbing = null!;
    public event Action<bool> Jumping = null!;
    public event Action<bool> FreeFalling = null!;
    public event Action<bool> FallingDown = null!;
    public event Action<bool> GettingUp = null!;
    public event Action<bool> Ragdoll = null!;
    public event Action<bool> PlatformStanding = null!;
    public event Action<bool> MoveToFinished = null!;
    public event Action<bool, BasePart?> Seated = null!;
    public event Action<int, int> StateChanged = null!;
    public event Action<int, bool> StateEnabledChanged = null!;
    public event Action<BasePart, BasePart> Touched = null!;
}
