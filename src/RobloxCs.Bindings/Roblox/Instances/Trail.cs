using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Trail : Instance
{
    // Properties
    public object? Attachment0 { get; set; } = null!;
    public object? Attachment1 { get; set; } = null!;
    public float Brightness { get; set; }
    public ColorSequence Color { get; set; }
    public bool Enabled { get; set; }
    public bool FaceCamera { get; set; }
    public float Lifetime { get; set; }
    public float LightEmission { get; set; }
    public float LightInfluence { get; set; }
    public float MaxLength { get; set; }
    public float MinLength { get; set; }
    public object? Texture { get; set; } = null!;
    public float TextureLength { get; set; }
    public object? TextureMode { get; set; } = null!;
    public NumberSequence Transparency { get; set; }
    public NumberSequence WidthScale { get; set; }

    // Methods
    public object Clear() => null!;

}
