using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Decal : FaceInstance
{
    // Properties
    public Color3 Color3 { get; set; }
    public object? ColorMap { get; set; } = null!;
    public string? ColorMapContent { get; set; } = null!;
    public float Rotation { get; set; }
    public object? Texture { get; set; } = null!;
    public string? TextureContent { get; set; } = null!;
    public float Transparency { get; set; }
    public Vector2 UVOffset { get; set; }
    public Vector2 UVScale { get; set; }
    public int ZIndex { get; set; }

}
