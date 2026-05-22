using System;

namespace Roblox.Instances;

public class AudioSpeechToText : Instance
{
    // Properties
    public bool Enabled { get; set; }
    public string? Text { get; set; } = null!;
    public bool VoiceDetected { get; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
