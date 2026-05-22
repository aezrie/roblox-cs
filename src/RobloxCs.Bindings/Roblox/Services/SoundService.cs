using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class SoundService : Instance
{
    // Properties
    public bool AcousticSimulationEnabled { get; set; }
    public object? AmbientReverb { get; set; } = null!;
    public float DistanceFactor { get; set; }
    public float DopplerScale { get; set; }
    public bool RespectFilteringEnabled { get; set; }
    public float RolloffScale { get; set; }

    // Methods
    public object[] GetListener() => default!;
    public double GetMixerTime() => default!;
    public object PlayLocalSound(Instance? sound) => null!;
    public object SetInputDevice(object? nameOrInstance, string? guidOrPin) => null!;
    public object SetListener(object? listenerType, object[]? listener) => null!;

}
