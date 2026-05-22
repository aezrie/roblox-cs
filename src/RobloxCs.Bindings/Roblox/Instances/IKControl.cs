using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class IKControl : Instance
{
    // Properties
    public Instance? ChainRoot { get; set; } = null!;
    public bool Enabled { get; set; }
    public Instance? EndEffector { get; set; } = null!;
    public CFrame EndEffectorOffset { get; set; }
    public CFrame Offset { get; set; }
    public Instance? Pole { get; set; } = null!;
    public int Priority { get; set; }
    public float SmoothTime { get; set; }
    public Instance? Target { get; set; } = null!;
    public object? Type { get; set; } = null!;
    public float Weight { get; set; }

    // Methods
    public int GetChainCount() => default!;
    public float GetChainLength() => default!;
    public CFrame GetNodeLocalCFrame(int index) => default!;
    public CFrame GetNodeWorldCFrame(int index) => default!;
    public CFrame GetRawFinalTarget() => default!;
    public CFrame GetSmoothedFinalTarget() => default!;

}
