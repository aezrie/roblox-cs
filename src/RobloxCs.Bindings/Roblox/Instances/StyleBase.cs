using System;

namespace Roblox.Instances;

public class StyleBase : Instance
{
    // Methods
    public object GetStyleRules() => null!;
    public object InsertStyleRule(object? rule, object? priority) => null!;
    public object SetStyleRules(object? rules) => null!;

    // Events
    public event Action StyleRulesChanged = null!;
}
