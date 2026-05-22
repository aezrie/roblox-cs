using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class WrapLayer : BaseWrap
{
    // Properties
    public object? AutoSkin { get; set; } = null!;
    public bool Enabled { get; set; }
    public int Order { get; set; }
    public float Puffiness { get; set; }
    public CFrame ReferenceOriginWorld { get; }

}
