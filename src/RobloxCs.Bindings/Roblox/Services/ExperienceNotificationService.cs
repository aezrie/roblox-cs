using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class ExperienceNotificationService : Instance
{
    // Methods
    public object PromptOptIn() => null!;
    public bool CanPromptOptInAsync() => default!;

    // Events
    public event Action OptInPromptClosed = null!;
}
