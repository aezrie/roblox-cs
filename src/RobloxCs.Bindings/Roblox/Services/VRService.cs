using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class VRService : Instance
{
    // Properties
    public object? AutomaticScaling { get; set; } = null!;
    public bool AvatarGestures { get; set; }
    public object? ControllerModels { get; set; } = null!;
    public bool FadeOutViewOnCollision { get; set; }
    public object? GuiInputUserCFrame { get; set; } = null!;
    public object? LaserPointer { get; set; } = null!;
    public bool ThirdPersonFollowCamEnabled { get; }
    public bool VREnabled { get; }

    // Methods
    public object GetTouchpadMode(object? pad) => null!;
    public CFrame GetUserCFrame(object? type) => default!;
    public bool GetUserCFrameEnabled(object? type) => default!;
    public object RecenterUserHeadCFrame() => null!;
    public object RequestNavigation(CFrame cframe, object? inputUserCFrame) => null!;
    public object SetTouchpadMode(object? pad, object? mode) => null!;

    // Events
    public event Action<CFrame, object> NavigationRequested = null!;
    public event Action<object, object> TouchpadModeChanged = null!;
    public event Action<object, CFrame> UserCFrameChanged = null!;
    public event Action<object, bool> UserCFrameEnabled = null!;
}
