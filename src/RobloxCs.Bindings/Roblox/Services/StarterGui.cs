using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class StarterGui : BasePlayerGui
{
    // Properties
    public object? ScreenOrientation { get; set; } = null!;
    public bool ShowDevelopmentGui { get; set; }

    // Methods
    public bool GetCoreGuiEnabled(object? coreGuiType) => default!;
    public object SetCore(string? parameterName, object? value) => null!;
    public object SetCoreGuiEnabled(object? coreGuiType, bool enabled) => null!;
    public object GetCore(string? parameterName) => null!;

}
