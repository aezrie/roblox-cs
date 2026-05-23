using System;
using Roblox;
using Roblox.Instances;

namespace Examples;

[RobloxStruct]
public struct Point
{
    public float X { get; set; }
    public float Y { get; set; }
}

public struct Color
{
    public float R, G, B;
}

public class Phase4Test
{
    public void Run()
    {
        // Test Struct Emission & Initializers
        var p1 = new Point { X = 10, Y = 20 };
        
        // Test Clone Inserter (Assignment)
        var p2 = p1; 
        p2.X = 100; // p1.X should still be 10 in C#, so p2 must be a clone in Luau

        // Test Clone Inserter (Arguments)
        PrintPoint(p1);

        // Test With Expression
        var p3 = p1 with { Y = 50 };

        // Test Pattern Matching (is)
        var part = new Part();
        if (part is BasePart bp)
        {
            Console.WriteLine("It is a BasePart: " + bp.Name);
        }

        // Test Pattern Matching (switch)
        object obj = part;
        switch (obj)
        {
            case BasePart p:
                Console.WriteLine("Switch: BasePart " + p.Name);
                break;
            case string s:
                Console.WriteLine("Switch: string " + s);
                break;
            default:
                Console.WriteLine("Switch: default");
                break;
        }
    }

    private void PrintPoint(Point p)
    {
        Console.WriteLine($"Point: {p.X}, {p.Y}");
    }
}
