using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class PluginDragEvent : Instance
{
    // Properties
    public string? Data { get; } = null!;
    public string? MimeType { get; } = null!;
    public Vector2 Position { get; }
    public string? Sender { get; } = null!;

}
