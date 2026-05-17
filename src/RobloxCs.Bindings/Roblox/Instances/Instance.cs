using System;

namespace Roblox.Instances;

public abstract class Instance
{
    // Properties
    public string Name { get; set; } = null!;
    public Instance? Parent { get; set; }
    public bool Archivable { get; set; }

    // Children / descendants
    public Instance[] GetChildren() => null!;
    public Instance[] GetDescendants() => null!;
    public string GetFullName() => null!;

    // Search
    public Instance? FindFirstChild(string name, bool recursive = false) => null!;
    public Instance? FindFirstChildOfClass(string className) => null!;
    public Instance? FindFirstChildWhichIsA(string className, bool recursive = false) => null!;
    public Instance? FindFirstAncestor(string name) => null!;
    public Instance? FindFirstAncestorOfClass(string className) => null!;
    public Instance? FindFirstAncestorWhichIsA(string className) => null!;
    public Instance? FindFirstDescendant(string name) => null!;
    public Instance? WaitForChild(string childName, float timeOut = 0) => null!;

    // Generic overloads for typed access
    public T? FindFirstChild<T>(string name, bool recursive = false) where T : Instance => null!;
    public T? FindFirstChildOfClass<T>() where T : Instance => null!;
    public T? FindFirstChildWhichIsA<T>(bool recursive = false) where T : Instance => null!;
    public T? WaitForChild<T>(string childName, float timeOut = 0) where T : Instance => null!;

    // Hierarchy checks
    public bool IsA(string className) => false;
    public bool IsAncestorOf(Instance descendant) => false;
    public bool IsDescendantOf(Instance ancestor) => false;

    // Mutation
    public Instance Clone() => null!;
    public void Destroy() { }
    public void ClearAllChildren() { }

    // Tags
    public void AddTag(string tag) { }
    public void RemoveTag(string tag) { }
    public bool HasTag(string tag) => false;
    public object[] GetTags() => null!;

    // Attributes
    public object GetAttribute(string attribute) => null!;
    public void SetAttribute(string attribute, object value) { }
    public System.Collections.Generic.Dictionary<string, object> GetAttributes() => null!;

    // Events
    public event Action<Instance> ChildAdded = null!;
    public event Action<Instance> ChildRemoved = null!;
    public event Action<Instance> DescendantAdded = null!;
    public event Action<Instance> DescendantRemoving = null!;
    public event Action<Instance, Instance> AncestryChanged = null!;
    public event Action<string> AttributeChanged = null!;
    public event Action Destroying = null!;
}
