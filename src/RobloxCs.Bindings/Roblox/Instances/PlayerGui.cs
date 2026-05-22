using System;

namespace Roblox.Instances;

public class PlayerGui : BasePlayerGui
{
    // Properties
    public object? CurrentScreenOrientation { get; } = null!;
    public object? ScreenOrientation { get; set; } = null!;
    public object? SelectionImageObject { get; set; } = null!;

}
