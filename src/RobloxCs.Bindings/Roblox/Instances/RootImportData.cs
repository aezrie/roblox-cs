using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class RootImportData : BaseImportData
{
    // Properties
    public bool AddModelToInventory { get; set; }
    public bool Anchored { get; set; }
    public float AnimationIdForRestPose { get; set; }
    public string? ExistingPackageId { get; set; } = null!;
    public Vector3 FileDimensions { get; }
    public bool ImportAsModelAsset { get; set; }
    public bool ImportAsPackage { get; set; }
    public bool InsertInWorkspace { get; set; }
    public bool InsertWithScenePosition { get; set; }
    public bool InvertNegativeFaces { get; set; }
    public bool KeepZeroInfluenceBones { get; set; }
    public bool MergeMeshes { get; set; }
    public object? PhysicalConstraintType { get; set; } = null!;
    public float PolygonCount { get; }
    public long PreferredUploadId { get; set; }
    public object? RestPose { get; set; } = null!;
    public object? RigScale { get; set; } = null!;
    public object? RigType { get; set; } = null!;
    public bool RigVisualization { get; set; }
    public float ScaleFactor { get; set; }
    public object? ScaleUnit { get; set; } = null!;
    public bool UseSceneOriginAsPivot { get; set; }
    public bool UsesCages { get; set; }
    public bool ValidateUgcBody { get; set; }
    public long VersionedAssetId { get; set; }
    public object? WorldForward { get; set; } = null!;
    public object? WorldUp { get; set; } = null!;

}
