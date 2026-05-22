using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class HttpService : Instance
{
    // Methods
    public object CreateWebStreamClient(object? streamClientType, System.Collections.Generic.Dictionary<string, object> requestOptions) => null!;
    public string GenerateGUID(bool wrapInCurlyBraces = true) => default!;
    public object GetSecret(string? key) => null!;
    public object JSONDecode(string? input) => null!;
    public string JSONEncode(object? input) => default!;
    public string UrlEncode(string? input) => default!;
    public string GetAsync(object? url, bool nocache = false, object? headers = null) => default!;
    public string PostAsync(object? url, string? data, object? contenttype = null, bool compress = false, object? headers = null) => default!;
    public System.Collections.Generic.Dictionary<string, object> RequestAsync(System.Collections.Generic.Dictionary<string, object> requestOptions) => default!;

}
