using System;

namespace Roblox.Instances;

public class StyleQuery : Instance
{
    // Properties
    public bool IsActive { get; }

    // Methods
    public object GetCondition(string? name) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetConditions() => default!;
    public object SetCondition(string? name, object? value) => null!;
    public object SetConditions(System.Collections.Generic.Dictionary<string, object> conditions) => null!;

}
