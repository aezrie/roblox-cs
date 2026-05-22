using System;

namespace Roblox.Instances;

public class AudioSearchParams : Instance
{
    // Properties
    public string? Album { get; set; } = null!;
    public string? Artist { get; set; } = null!;
    public object? AudioSubType { get; set; } = null!;
    public int MaxDuration { get; set; }
    public int MinDuration { get; set; }
    public string? SearchKeyword { get; set; } = null!;
    public string? Tag { get; set; } = null!;
    public string? Title { get; set; } = null!;

}
