using System;

namespace Roblox.Instances;

public class ReflectionMetadataItem : Instance
{
    // Properties
    public bool Browsable { get; set; }
    public string? ClassCategory { get; set; } = null!;
    public bool ClientOnly { get; set; }
    public string? Constraint { get; set; } = null!;
    public bool Deprecated { get; set; }
    public bool EditingDisabled { get; set; }
    public string? EditorType { get; set; } = null!;
    public string? FFlag { get; set; } = null!;
    public bool IsBackend { get; set; }
    public int PropertyOrder { get; set; }
    public string? ScriptContext { get; set; } = null!;
    public bool ServerOnly { get; set; }
    public string? SliderScaling { get; set; } = null!;
    public double UIMaximum { get; set; }
    public double UIMinimum { get; set; }
    public double UINumTicks { get; set; }

}
