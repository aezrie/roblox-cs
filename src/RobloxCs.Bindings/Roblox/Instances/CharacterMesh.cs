using System;

namespace Roblox.Instances;

public class CharacterMesh : CharacterAppearance
{
    // Properties
    public string? BaseTextureContent { get; set; } = null!;
    public long BaseTextureId { get; set; }
    public object? BodyPart { get; set; } = null!;
    public string? MeshContent { get; set; } = null!;
    public long MeshId { get; set; }
    public string? OverlayTextureContent { get; set; } = null!;
    public long OverlayTextureId { get; set; }

}
