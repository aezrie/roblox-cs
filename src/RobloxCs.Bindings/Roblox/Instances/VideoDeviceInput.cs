using System;

namespace Roblox.Instances;

public class VideoDeviceInput : Instance
{
    // Properties
    public bool Active { get; set; }
    public string? CameraId { get; set; } = null!;
    public object? CaptureQuality { get; set; } = null!;
    public bool IsReady { get; }

}
