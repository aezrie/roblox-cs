using System;

namespace Roblox.Instances;

public class Capture : Object
{
    // Properties
    public object? CaptureTime { get; } = null!;
    public object? CaptureType { get; } = null!;
    public string? LocalId { get; } = null!;
    public long SourcePlaceId { get; }
    public long SourceUniverseId { get; }

}
