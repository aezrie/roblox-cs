using System;

namespace Roblox.Instances;

public class StyleRule : StyleBase
{
    // Properties
    public int Priority { get; set; }
    public string? Selector { get; set; } = null!;
    public string? SelectorError { get; } = null!;

    // Methods
    public object GetDefaultPropertyTransition() => null!;
    public System.Collections.Generic.Dictionary<string, object> GetProperties() => default!;
    public object GetProperty(string? name) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetPropertyTransitions() => default!;
    public object SetDefaultPropertyTransition(object? transitionParams) => null!;
    public object SetProperties(System.Collections.Generic.Dictionary<string, object> styleProperties) => null!;
    public object SetProperty(string? name, object? value) => null!;
    public object SetPropertyTransition(string? property, object? transitionParams) => null!;
    public object SetPropertyTransitions(System.Collections.Generic.Dictionary<string, object> properties) => null!;

}
