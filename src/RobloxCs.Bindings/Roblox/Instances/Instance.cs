using System;
namespace Roblox.Instances;
public class Instance
{
    public string Name { get; set; } = null!;
    public Instance Parent { get; set; } = null!;

    public T? FindFirstChild<T>(string name) where T : class => null!;
    public T? WaitForChild<T>(string name) where T : class => null!;
    public T? FindFirstChildOfClass<T>() where T : class => null!;
    public Instance[] GetChildren() => null!;
    public Instance[] GetDescendants() => null!;
    public bool IsA(string className) => false;
    public void Destroy() { }

    public event Action<Instance> ChildAdded = null!;
    public event Action<Instance> ChildRemoved = null!;
}
