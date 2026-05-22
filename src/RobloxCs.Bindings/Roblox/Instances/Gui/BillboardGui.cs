using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class BillboardGui : LayerCollector
{
    // Properties
    public bool Active { get; set; }
    public Instance? Adornee { get; set; } = null!;
    public bool AlwaysOnTop { get; set; }
    public float Brightness { get; set; }
    public bool ClipsDescendants { get; set; }
    public float CurrentDistance { get; }
    public float DistanceStep { get; set; }
    public Vector3 ExtentsOffset { get; set; }
    public Vector3 ExtentsOffsetWorldSpace { get; set; }
    public float LightInfluence { get; set; }
    public float MaxDistance { get; set; }
    public Instance? PlayerToHideFrom { get; set; } = null!;
    public UDim2 Size { get; set; }
    public Vector2 SizeOffset { get; set; }
    public Vector3 StudsOffset { get; set; }
    public Vector3 StudsOffsetWorldSpace { get; set; }

}
