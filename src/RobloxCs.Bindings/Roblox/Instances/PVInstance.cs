using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public abstract class PVInstance : Instance
{
    // Methods
    public CFrame GetPivot() => default!;
    public object PivotTo(CFrame targetCFrame) => null!;

}
