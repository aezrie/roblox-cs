using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Beam : Instance
{
    // Properties
    public object? Attachment0 { get; set; } = null!;
    public object? Attachment1 { get; set; } = null!;
    public float Brightness { get; set; }
    public ColorSequence Color { get; set; }
    public float CurveSize0 { get; set; }
    public float CurveSize1 { get; set; }
    public bool Enabled { get; set; }
    public bool FaceCamera { get; set; }
    public float LightEmission { get; set; }
    public float LightInfluence { get; set; }
    public int Segments { get; set; }
    public object? Texture { get; set; } = null!;
    public float TextureLength { get; set; }
    public object? TextureMode { get; set; } = null!;
    public float TextureSpeed { get; set; }
    public NumberSequence Transparency { get; set; }
    public float Width0 { get; set; }
    public float Width1 { get; set; }
    public float ZOffset { get; set; }

    // Methods
    public object SetTextureOffset(float offset = 0) => null!;

}
