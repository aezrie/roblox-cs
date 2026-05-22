using System;

namespace Roblox.Instances;

public class CompressorSoundEffect : SoundEffect
{
    // Properties
    public float Attack { get; set; }
    public float GainMakeup { get; set; }
    public float Ratio { get; set; }
    public float Release { get; set; }
    public Instance? SideChain { get; set; } = null!;
    public float Threshold { get; set; }

}
