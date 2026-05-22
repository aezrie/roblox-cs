using System;

namespace Roblox.Instances;

public class DialogChoice : Instance
{
    // Properties
    public bool GoodbyeChoiceActive { get; set; }
    public string? GoodbyeDialog { get; set; } = null!;
    public string? ResponseDialog { get; set; } = null!;
    public string? UserDialog { get; set; } = null!;

}
