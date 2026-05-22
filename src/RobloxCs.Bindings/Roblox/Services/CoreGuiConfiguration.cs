using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class CoreGuiConfiguration : Instance
{
    // Properties
    public object? CapturesViewConfiguration { get; set; } = null!;
    public object? PlayerListConfiguration { get; set; } = null!;
    public object? SelfViewConfiguration { get; set; } = null!;

}
