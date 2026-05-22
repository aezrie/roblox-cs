using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Bone : Attachment
{
    // Properties
    public CFrame Transform { get; set; }
    public CFrame TransformedWorldCFrame { get; }

}
