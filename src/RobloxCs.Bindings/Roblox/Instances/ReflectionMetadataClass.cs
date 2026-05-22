using System;

namespace Roblox.Instances;

public class ReflectionMetadataClass : ReflectionMetadataItem
{
    // Properties
    public int ExplorerImageIndex { get; set; }
    public int ExplorerOrder { get; set; }
    public bool Insertable { get; set; }
    public string? PreferredParent { get; set; } = null!;

}
