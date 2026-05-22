using System;

namespace Roblox.Instances;

public class ReverbSoundEffect : SoundEffect
{
    // Properties
    public float DecayTime { get; set; }
    public float Density { get; set; }
    public float Diffusion { get; set; }
    public float DryLevel { get; set; }
    public float WetLevel { get; set; }

}
