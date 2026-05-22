using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class RenderSettings : Instance
{
    // Properties
    public int AutoFRMLevel { get; set; }
    public bool EagerBulkExecution { get; set; }
    public object? EditQualityLevel { get; set; } = null!;
    public bool EnableVRMode { get; set; }
    public bool ExportMergeByMaterial { get; set; }
    public object? FrameRateManager { get; set; } = null!;
    public object? GraphicsMode { get; set; } = null!;
    public int MeshCacheSize { get; set; }
    public object? MeshPartDetailLevel { get; set; } = null!;
    public object? QualityLevel { get; set; } = null!;
    public bool ReloadAssets { get; set; }
    public bool RenderCSGTrianglesDebug { get; set; }
    public bool ShowBoundingBoxes { get; set; }
    public object? ViewMode { get; set; } = null!;

    // Methods
    public int GetMaxQualityLevel() => default!;

}
