using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class GeometryService : Instance
{
    // Methods
    public object[] CalculateConstraintsToPreserve(Instance? source, object[]? destination, System.Collections.Generic.Dictionary<string, object> options = null) => default!;
    public object CreateSolidPrimitive(object? type, System.Collections.Generic.Dictionary<string, object> options = null) => null!;
    public object[] GenerateFragmentSites(object? part, System.Collections.Generic.Dictionary<string, object> options = null) => default!;
    public object[] FragmentAsync(object? part, object[]? sites, System.Collections.Generic.Dictionary<string, object> options = null) => default!;
    public object[] IntersectAsync(Instance? part, object[]? parts, System.Collections.Generic.Dictionary<string, object> options = null) => default!;
    public object[] SubtractAsync(Instance? part, object[]? parts, System.Collections.Generic.Dictionary<string, object> options = null) => default!;
    public object SweepPartAsync(object? part, object[]? cframes, System.Collections.Generic.Dictionary<string, object> options = null) => null!;
    public object[] UnionAsync(Instance? part, object[]? parts, System.Collections.Generic.Dictionary<string, object> options = null) => default!;

}
