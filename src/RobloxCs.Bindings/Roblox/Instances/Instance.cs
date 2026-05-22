using System;

namespace Roblox.Instances;

public abstract class Instance : Object
{
    // Properties
    public bool Archivable { get; set; }
    public object? Capabilities { get; set; } = null!;
    public string? Name { get; set; } = null!;
    public Instance? Parent { get; set; } = null!;
    public bool Sandboxed { get; set; }

    // Methods
    public object AddTag(string? tag) => null!;
    public object ClearAllChildren() => null!;
    public Instance Clone() => null!;
    public object Destroy() => null!;
    public Instance FindFirstAncestor(string? name) => null!;
    public Instance FindFirstAncestorOfClass(string? className) => null!;
    public Instance FindFirstAncestorWhichIsA(string? className) => null!;
    public Instance FindFirstChild(string? name, bool recursive = false) => null!;
    public Instance FindFirstChildOfClass(string? className) => null!;
    public Instance FindFirstChildWhichIsA(string? className, bool recursive = false) => null!;
    public Instance FindFirstDescendant(string? name) => null!;
    public object GetActor() => null!;
    public object GetAttribute(string? attribute) => null!;
    public object GetAttributeChangedSignal(string? attribute) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetAttributes() => default!;
    public object GetChildren() => null!;
    public object GetDescendants() => null!;
    public string GetFullName() => default!;
    public object GetStyled(string? name, object? selector) => null!;
    public object GetStyledPropertyChangedSignal(string? property) => null!;
    public object[] GetTags() => default!;
    public bool HasTag(string? tag) => default!;
    public bool IsAncestorOf(Instance? descendant) => default!;
    public bool IsDescendantOf(Instance? ancestor) => default!;
    public bool IsPropertyModified(string? property) => default!;
    public object QueryDescendants(string? selector) => null!;
    public object RemoveTag(string? tag) => null!;
    public object ResetPropertyToDefault(string? property) => null!;
    public object SetAttribute(string? attribute, object? value) => null!;
    public Instance WaitForChild(string? childName, double timeOut) => null!;

    // Events
    public event Action<Instance, Instance> AncestryChanged = null!;
    public event Action<string> AttributeChanged = null!;
    public event Action<Instance> ChildAdded = null!;
    public event Action<Instance> ChildRemoved = null!;
    public event Action<Instance> DescendantAdded = null!;
    public event Action<Instance> DescendantRemoving = null!;
    public event Action Destroying = null!;
    public event Action StyledPropertiesChanged = null!;
}
