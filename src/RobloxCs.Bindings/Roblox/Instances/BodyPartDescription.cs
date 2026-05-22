using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class BodyPartDescription : Instance
{
    // Properties
    public long AssetId { get; set; }
    public object? BodyPart { get; set; } = null!;
    public Color3 Color { get; set; }
    public string? HeadShape { get; set; } = null!;
    public Instance? Instance { get; set; } = null!;

}
