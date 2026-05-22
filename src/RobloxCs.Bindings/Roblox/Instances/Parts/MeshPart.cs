using System;

namespace Roblox.Instances;

public class MeshPart : TriangleMeshPart
{
    // Properties
    public string? TextureContent { get; set; } = null!;
    public object? TextureID { get; set; } = null!;

    // Methods
    public object ApplyMesh(Instance? meshPart) => null!;

}
