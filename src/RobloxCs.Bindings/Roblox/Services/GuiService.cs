using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class GuiService : Instance
{
    // Properties
    public bool AutoSelectGuiEnabled { get; set; }
    public bool GuiNavigationEnabled { get; set; }
    public bool MenuIsOpen { get; }
    public object? PreferredTextSize { get; } = null!;
    public object? SelectedObject { get; set; } = null!;
    public Rect TopbarInset { get; }
    public bool TouchControlsEnabled { get; set; }
    public object? ViewportDisplaySize { get; } = null!;

    // Methods
    public object CloseInspectMenu() => null!;
    public bool DismissNotification(string? notificationId) => default!;
    public bool GetEmotesMenuOpen() => default!;
    public bool GetGameplayPausedNotificationEnabled() => default!;
    public object[] GetGuiInset() => default!;
    public Rect GetInsetArea(object? screenInsets) => default!;
    public bool GetInspectMenuEnabled() => default!;
    public object InspectPlayerFromHumanoidDescription(Instance? humanoidDescription, string? name) => null!;
    public object InspectPlayerFromUserId(long userId) => null!;
    public bool IsTenFootInterface() => default!;
    public object Select(Instance? selectionParent) => null!;
    public string SendNotification(System.Collections.Generic.Dictionary<string, object> notificationInfo) => default!;
    public object SetEmotesMenuOpen(bool isOpen) => null!;
    public object SetGameplayPausedNotificationEnabled(bool enabled) => null!;
    public object SetInspectMenuEnabled(bool enabled) => null!;

    // Events
    public event Action MenuClosed = null!;
    public event Action MenuOpened = null!;
}
