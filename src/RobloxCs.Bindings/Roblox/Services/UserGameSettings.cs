using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class UserGameSettings : Instance
{
    // Properties
    public object? ComputerCameraMovementMode { get; set; } = null!;
    public object? ComputerMovementMode { get; set; } = null!;
    public object? ControlMode { get; set; } = null!;
    public float GamepadCameraSensitivity { get; set; }
    public float MouseSensitivity { get; set; }
    public int RCCProfilerRecordFrameRate { get; set; }
    public int RCCProfilerRecordTimeFrame { get; set; }
    public object? RotationType { get; set; } = null!;
    public object? SavedQualityLevel { get; set; } = null!;
    public object? TouchCameraMovementMode { get; set; } = null!;
    public object? TouchMovementMode { get; set; } = null!;

    // Methods
    public int GetCameraYInvertValue() => default!;
    public bool GetOnboardingCompleted(string? onboardingId) => default!;
    public bool InFullScreen() => default!;
    public bool InStudioMode() => default!;
    public object SetCameraYInvertVisible() => null!;
    public object SetGamepadCameraSensitivityVisible() => null!;
    public object SetOnboardingCompleted(string? onboardingId) => null!;

    // Events
    public event Action<bool> FullscreenChanged = null!;
    public event Action<bool> StudioModeChanged = null!;
}
