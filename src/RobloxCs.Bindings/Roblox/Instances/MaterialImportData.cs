using System;

namespace Roblox.Instances;

public class MaterialImportData : BaseImportData
{
    // Properties
    public string? DiffuseFilePath { get; set; } = null!;
    public string? EmissiveFilePath { get; set; } = null!;
    public bool IsPbr { get; }
    public string? MetalnessFilePath { get; set; } = null!;
    public string? NormalFilePath { get; set; } = null!;
    public string? RoughnessFilePath { get; set; } = null!;

}
