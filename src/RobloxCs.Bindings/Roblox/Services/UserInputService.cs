using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class UserInputService : Instance
{
    // Properties
    public bool AccelerometerEnabled { get; }
    public bool GamepadEnabled { get; }
    public bool GyroscopeEnabled { get; }
    public bool KeyboardEnabled { get; }
    public object? MouseBehavior { get; set; } = null!;
    public float MouseDeltaSensitivity { get; set; }
    public bool MouseEnabled { get; }
    public object? MouseIcon { get; set; } = null!;
    public string? MouseIconContent { get; set; } = null!;
    public bool MouseIconEnabled { get; set; }
    public Vector2 OnScreenKeyboardPosition { get; }
    public Vector2 OnScreenKeyboardSize { get; }
    public bool OnScreenKeyboardVisible { get; }
    public object? PreferredInput { get; } = null!;
    public bool TouchEnabled { get; }
    public bool VREnabled { get; }

    // Methods
    public object CreateVirtualInput() => null!;
    public bool GamepadSupports(object? gamepadNum, object? gamepadKeyCode) => default!;
    public object[] GetConnectedGamepads() => default!;
    public object GetDeviceAcceleration() => null!;
    public object GetDeviceGravity() => null!;
    public object[] GetDeviceRotation() => default!;
    public object GetFocusedTextBox() => null!;
    public bool GetGamepadConnected(object? gamepadNum) => default!;
    public object GetGamepadState(object? gamepadNum) => null!;
    public object GetImageForKeyCode(object? keyCode) => null!;
    public object GetKeysPressed() => null!;
    public object GetLastInputType() => null!;
    public object GetMouseButtonsPressed() => null!;
    public Vector2 GetMouseDelta() => default!;
    public Vector2 GetMouseLocation() => default!;
    public object[] GetNavigationGamepads() => default!;
    public string GetStringForKeyCode(object? keyCode) => default!;
    public object[] GetSupportedGamepadKeyCodes(object? gamepadNum) => default!;
    public bool IsGamepadButtonDown(object? gamepadNum, object? gamepadKeyCode) => default!;
    public bool IsKeyDown(object? keyCode) => default!;
    public bool IsMouseButtonPressed(object? mouseButton) => default!;
    public bool IsNavigationGamepad(object? gamepadEnum) => default!;
    public object RecenterUserHeadCFrame() => null!;
    public object SetNavigationGamepad(object? gamepadEnum, bool enabled) => null!;

    // Events
    public event Action<object> DeviceAccelerationChanged = null!;
    public event Action<object> DeviceGravityChanged = null!;
    public event Action<object, CFrame> DeviceRotationChanged = null!;
    public event Action<object> GamepadConnected = null!;
    public event Action<object> GamepadDisconnected = null!;
    public event Action<object, bool> InputBegan = null!;
    public event Action<object, bool> InputChanged = null!;
    public event Action<object, bool> InputEnded = null!;
    public event Action JumpRequest = null!;
    public event Action<object> LastInputTypeChanged = null!;
    public event Action<float, Vector2, float, bool> PointerAction = null!;
    public event Action<object> TextBoxFocusReleased = null!;
    public event Action<object> TextBoxFocused = null!;
    public event Action<object, int, bool> TouchDrag = null!;
    public event Action<object, bool> TouchEnded = null!;
    public event Action<object[], object, bool> TouchLongPress = null!;
    public event Action<object, bool> TouchMoved = null!;
    public event Action<object[], Vector2, Vector2, object, bool> TouchPan = null!;
    public event Action<object[], float, float, object, bool> TouchPinch = null!;
    public event Action<object[], float, float, object, bool> TouchRotate = null!;
    public event Action<object, bool> TouchStarted = null!;
    public event Action<object, int, bool> TouchSwipe = null!;
    public event Action<object[], bool> TouchTap = null!;
    public event Action<Vector2, bool> TouchTapInWorld = null!;
    public event Action WindowFocusReleased = null!;
    public event Action WindowFocused = null!;
}
