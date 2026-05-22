using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ProceduralModel : Model
{
    // Properties
    public string? GenerationError { get; } = null!;
    public object? Generator { get; set; } = null!;
    public Vector3 Size { get; set; }

    // Methods
    public bool ForceGeneration() => default!;
    public bool WaitForGenerationAsync() => default!;

}
