using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class StarterPlayer : Instance
{
    // Properties
    public bool AutoJumpEnabled { get; set; }
    public float CameraMaxZoomDistance { get; set; }
    public float CameraMinZoomDistance { get; set; }
    public object? CameraMode { get; set; } = null!;
    public bool CharacterBreakJointsOnDeath { get; set; }
    public float CharacterJumpHeight { get; set; }
    public float CharacterJumpPower { get; set; }
    public float CharacterMaxSlopeAngle { get; set; }
    public bool CharacterUseJumpPower { get; set; }
    public float CharacterWalkSpeed { get; set; }
    public bool ClassicDeath { get; set; }
    public object? DevCameraOcclusionMode { get; set; } = null!;
    public object? DevComputerCameraMovementMode { get; set; } = null!;
    public object? DevComputerMovementMode { get; set; } = null!;
    public object? DevTouchCameraMovementMode { get; set; } = null!;
    public object? DevTouchMovementMode { get; set; } = null!;
    public bool EnableMouseLockOption { get; set; }
    public float HealthDisplayDistance { get; set; }
    public bool LoadCharacterAppearance { get; set; }
    public object? LuaCharacterController { get; set; } = null!;
    public float NameDisplayDistance { get; set; }
    public bool UserEmotesEnabled { get; set; }

}
