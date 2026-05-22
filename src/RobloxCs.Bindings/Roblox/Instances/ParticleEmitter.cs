using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ParticleEmitter : Instance
{
    // Properties
    public Vector3 Acceleration { get; set; }
    public float Brightness { get; set; }
    public ColorSequence Color { get; set; }
    public float Drag { get; set; }
    public object? EmissionDirection { get; set; } = null!;
    public bool Enabled { get; set; }
    public bool FlipbookBlendFrames { get; set; }
    public NumberRange FlipbookFramerate { get; set; }
    public string? FlipbookIncompatible { get; set; } = null!;
    public object? FlipbookLayout { get; set; } = null!;
    public object? FlipbookMode { get; set; } = null!;
    public int FlipbookSizeX { get; set; }
    public int FlipbookSizeY { get; set; }
    public bool FlipbookStartRandom { get; set; }
    public NumberRange Lifetime { get; set; }
    public float LightEmission { get; set; }
    public float LightInfluence { get; set; }
    public bool LockedToPart { get; set; }
    public object? Orientation { get; set; } = null!;
    public float Rate { get; set; }
    public NumberRange RotSpeed { get; set; }
    public NumberRange Rotation { get; set; }
    public object? Shape { get; set; } = null!;
    public object? ShapeInOut { get; set; } = null!;
    public float ShapePartial { get; set; }
    public object? ShapeStyle { get; set; } = null!;
    public NumberSequence Size { get; set; }
    public NumberRange Speed { get; set; }
    public Vector2 SpreadAngle { get; set; }
    public NumberSequence Squash { get; set; }
    public object? Texture { get; set; } = null!;
    public float TimeScale { get; set; }
    public NumberSequence Transparency { get; set; }
    public float VelocityInheritance { get; set; }
    public bool WindAffectsDrag { get; set; }
    public float ZOffset { get; set; }

    // Methods
    public object Clear() => null!;
    public object Emit(int particleCount = default) => null!;

}
