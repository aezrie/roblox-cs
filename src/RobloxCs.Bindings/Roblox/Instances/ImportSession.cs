using System;

namespace Roblox.Instances;

public class ImportSession : Instance
{
    // Events
    public event Action<System.Collections.Generic.Dictionary<string, object>> UploadComplete = null!;
    public event Action<float> UploadProgress = null!;
}
