using Roblox.Datatypes;

namespace Roblox.Instances;

public abstract class PVInstance : Instance
{
    public CFrame GetPivot() => default;
    public void PivotTo(CFrame targetCFrame) { }
}
