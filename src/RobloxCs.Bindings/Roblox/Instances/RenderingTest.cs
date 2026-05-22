using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class RenderingTest : Instance
{
    // Properties
    public CFrame CFrame { get; set; }
    public int ComparisonDiffThreshold { get; set; }
    public object? ComparisonMethod { get; set; } = null!;
    public float ComparisonPsnrThreshold { get; set; }
    public string? Description { get; set; } = null!;
    public float FieldOfView { get; set; }
    public bool PerfTest { get; set; }
    public bool QualityAuto { get; set; }
    public int QualityLevel { get; set; }
    public int RenderingTestFrameCount { get; set; }
    public bool ShouldSkip { get; set; }
    public string? Ticket { get; set; } = null!;
    public int Timeout { get; set; }

    // Methods
    public object RenderdocTriggerCapture() => null!;

}
