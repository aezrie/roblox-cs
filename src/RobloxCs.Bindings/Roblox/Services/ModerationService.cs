using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class ModerationService : Instance
{
    // Methods
    public object BindReviewableContentEventProcessor(int priority, Delegate? callback) => null!;
    public string CreateReviewableContentKey(string? content) => default!;
    public string CreateReviewableContentAsync(System.Collections.Generic.Dictionary<string, object> config) => default!;
    public object InternalRequestReviewableContentReviewAsync(System.Collections.Generic.Dictionary<string, object> config) => null!;

}
