using System;

namespace Roblox.Instances;

public class VideoSampler : Object
{
    // Properties
    public double TimeLength { get; }
    public string? VideoContent { get; } = null!;

    // Methods
    public object[] GetSamplesAtTimesAsync(object[]? times) => default!;

}
