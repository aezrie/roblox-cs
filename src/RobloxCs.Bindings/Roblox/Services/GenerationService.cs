using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class GenerationService : Instance
{
    // Methods
    public object[] ConnectAsync(string? sessionId, string? sdp, string? type, string? relay) => default!;
    public bool DisconnectAsync(string? sessionId) => default!;
    public object[] GenerateMeshAsync(System.Collections.Generic.Dictionary<string, object> inputs, object? player, System.Collections.Generic.Dictionary<string, object> options, object? intermediateResultCallback) => default!;
    public object[] GenerateModelAsync(System.Collections.Generic.Dictionary<string, object> inputs, System.Collections.Generic.Dictionary<string, object> schema, object? options) => default!;
    public object[] GetVideoGenSessionAsync() => default!;
    public System.Collections.Generic.Dictionary<string, object> GetVideoGenTriggersAsync(string? sessionId, int lookbackSeconds) => default!;
    public object LoadGeneratedMeshAsync(string? generationId) => null!;
    public bool StartVideoGenSessionAsync(string? sessionId, string? prompt, string? imageData, string? imageS3Reference, System.Collections.Generic.Dictionary<string, object> triggers) => default!;
    public bool UpdateVideoGenSessionPromptAsync(string? sessionId, string? prompt, string? imageData, string? imageS3Reference, string? mode) => default!;
    public bool UpdateVideoGenSessionTriggersAsync(string? sessionId, System.Collections.Generic.Dictionary<string, object> triggers) => default!;

}
