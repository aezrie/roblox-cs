using System;
using System.Collections.Generic;
using System.Linq;
using Roblox.Instances;

namespace Examples;

public class LinqTest
{
    public void Run()
    {
        var parts = new List<Part>();
        
        // Simple LINQ
        var visibleParts = parts.Where(p => p.Transparency < 1).ToList();

        // LINQ Chain (Fusion target)
        var partNames = parts
            .Where(p => p.Parent == null)
            .Select(p => p.Name)
            .ToList();

        // LINQ Terminals
        bool hasAny = parts.Any(p => p.Name == "Target");
        bool allVisible = parts.All(p => p.Transparency == 0);
        var first = parts.FirstOrDefault();

        // Extension Method Test
        parts.MyCustomExtension();

        // List Operations
        parts.Add(new Part());
        int count = parts.Count;
        var firstPart = parts[0];
        parts.RemoveAt(0);
        parts.Clear();
    }
}

public static class Extensions
{
    public static void MyCustomExtension(this List<Part> list)
    {
        Console.WriteLine("Extension called!");
    }
}
