using System;

namespace Roblox.Instances;

public class Pages : Instance
{
    // Properties
    public bool IsFinished { get; }

    // Methods
    public object[] GetCurrentPage() => default!;
    public object AdvanceToNextPageAsync() => null!;

}
