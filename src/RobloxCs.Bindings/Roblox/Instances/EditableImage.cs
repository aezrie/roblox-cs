using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class EditableImage : Object
{
    // Properties
    public Vector2 Size { get; }

    // Methods
    public object Destroy() => null!;
    public object DrawCircle(Vector2 center, int radius, Color3 color, float transparency, object? combineType, object? antiAliasing = null) => null!;
    public object DrawImage(Vector2 position, object? image, object? combineType) => null!;
    public object DrawImageProjected(object? mesh, System.Collections.Generic.Dictionary<string, object> projection, System.Collections.Generic.Dictionary<string, object> brushConfig) => null!;
    public object DrawImageTransformed(Vector2 position, Vector2 scale, float rotation, object? image, object? options) => null!;
    public object DrawLine(Vector2 p1, Vector2 p2, Color3 color, float transparency, object? combineType, object? antiAliasing = null) => null!;
    public object DrawRectangle(Vector2 position, Vector2 size, Color3 color, float transparency, object? combineType) => null!;
    public object ReadPixelsBuffer(Vector2 position, Vector2 size) => null!;
    public object WritePixelsBuffer(Vector2 position, Vector2 size, object? buffer) => null!;

}
