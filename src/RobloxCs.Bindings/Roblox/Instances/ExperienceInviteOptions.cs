using System;

namespace Roblox.Instances;

public class ExperienceInviteOptions : Instance
{
    // Properties
    public string? InviteMessageId { get; set; } = null!;
    public long InviteUser { get; set; }
    public string? LaunchData { get; set; } = null!;
    public string? PromptMessage { get; set; } = null!;

}
