using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class ReflectionService : Instance
{
    // Methods
    public object GetClass(string? className, System.Collections.Generic.Dictionary<string, object> filter = null) => null!;
    public object[] GetClasses(System.Collections.Generic.Dictionary<string, object> filter = null) => default!;
    public object[] GetEventsOfClass(string? className, System.Collections.Generic.Dictionary<string, object> filter = null) => default!;
    public object[] GetMethodsOfClass(string? className, System.Collections.Generic.Dictionary<string, object> filter = null) => default!;
    public object[] GetPropertiesOfClass(string? className, System.Collections.Generic.Dictionary<string, object> filter = null) => default!;

}
