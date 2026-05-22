using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class ContextActionService : Instance
{
    // Methods
    public object BindAction(string? actionName, Delegate? functionToBind, bool createTouchButton, object[]? inputTypes) => null!;
    public object BindActionAtPriority(string? actionName, Delegate? functionToBind, bool createTouchButton, int priorityLevel, object[]? inputTypes) => null!;
    public object BindActivate(object? userInputTypeForActivation, object[]? keyCodesForActivation) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetAllBoundActionInfo() => default!;
    public System.Collections.Generic.Dictionary<string, object> GetBoundActionInfo(string? actionName) => default!;
    public string GetCurrentLocalToolIcon() => default!;
    public object SetDescription(string? actionName, string? description) => null!;
    public object SetImage(string? actionName, string? image) => null!;
    public object SetPosition(string? actionName, UDim2 position) => null!;
    public object SetTitle(string? actionName, string? title) => null!;
    public object UnbindAction(string? actionName) => null!;
    public object UnbindActivate(object? userInputTypeForActivation, object? keyCodeForActivation = null) => null!;
    public object UnbindAllActions() => null!;
    public Instance GetButton(string? actionName) => null!;

    // Events
    public event Action<Instance> LocalToolEquipped = null!;
    public event Action<Instance> LocalToolUnequipped = null!;
}
