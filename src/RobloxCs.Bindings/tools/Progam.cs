using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

// ── Fetch the API dump ───────────────────────────────────────────────────────
const string DumpUrl =
    "https://raw.githubusercontent.com/MaximumADHD/Roblox-Client-Tracker/roblox/API-Dump.json";

Console.WriteLine("Fetching Roblox API dump...");
using var http = new HttpClient();
var json = await http.GetStringAsync(DumpUrl);

var dump = JsonSerializer.Deserialize<ApiDump>(json, new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
})!;

Console.WriteLine($"Loaded {dump.Classes.Count} classes, {dump.Enums.Count} enums.");

// ── Output directory ─────────────────────────────────────────────────────────
var outDir = args.Length > 0
    ? args[0]
    : Path.Combine(AppContext.BaseDirectory, "Generated");

Console.WriteLine($"Writing to: {outDir}");

// ── Type mapping ─────────────────────────────────────────────────────────────
static string MapType(string robloxType, bool nullable = false)
{
    var mapped = robloxType switch
    {
        "bool"              => "bool",
        "boolean"           => "bool",
        "int"               => "int",
        "int64"             => "long",
        "float"             => "float",
        "double"            => "double",
        "string"            => "string",
        "void"              => "void",
        "Content"           => "string",
        "BinaryString"      => "string",
        "ProtectedString"   => "string",
        "Vector3"           => "Vector3",
        "Vector2"           => "Vector2",
        "CFrame"            => "CFrame",
        "Color3"            => "Color3",
        "UDim"              => "UDim",
        "UDim2"             => "UDim2",
        "Rect"              => "Rect",
        "NumberRange"       => "NumberRange",
        "NumberSequence"    => "NumberSequence",
        "ColorSequence"     => "ColorSequence",
        "Ray"               => "Ray",
        "Faces"             => "Faces",
        "Axes"              => "Axes",
        "BrickColor"        => "BrickColor",
        "Instance"          => "Instance",
        "Objects"           => "Instance[]",
        "Tuple"             => "object[]",
        "Variant"           => "object",
        "Dictionary"        => "System.Collections.Generic.Dictionary<string, object>",
        "Array"             => "object[]",
        "Function"          => "Delegate",
        "RBXScriptSignal"   => "object",
        "RBXScriptConnection" => "object",
        _                   => "object"
    };

    if (nullable && mapped is "string" or "Instance" or "Instance[]" or "object" or "object[]" or "Delegate")
        return mapped + "?";

    return mapped;
}

static bool NeedsDatatypesUsing(IEnumerable<ApiMember> members)
{
    var datatypes = new HashSet<string>
    {
        "Vector3", "Vector2", "CFrame", "Color3",
        "UDim", "UDim2", "Rect", "NumberRange",
        "NumberSequence", "ColorSequence", "Ray",
        "Faces", "Axes", "BrickColor"
    };

    foreach (var m in members)
    {
        if (m.MemberType == "Property" && datatypes.Contains(m.ValueType?.Name ?? ""))
            return true;
        if (m.MemberType is "Function" or "Callback")
        {
            if (datatypes.Contains(m.ReturnType?.Name ?? "")) return true;
            if (m.Parameters?.Any(p => datatypes.Contains(p.Type?.Name ?? "")) == true)
                return true;
        }
        if (m.MemberType == "Event")
        {
            if (m.Parameters?.Any(p => datatypes.Contains(p.Type?.Name ?? "")) == true)
                return true;
        }
    }
    return false;
}

static bool ShouldSkipMember(ApiMember m)
{
    if (m.Tags != null && (m.Tags.Contains("Deprecated") || m.Tags.Contains("Hidden") || m.Tags.Contains("NotScriptable")))
        return true;

    if (m.Security.ValueKind == JsonValueKind.String)
        return m.Security.GetString() != "None";

    if (m.Security.ValueKind == JsonValueKind.Object)
    {
        if (m.Security.TryGetProperty("Read", out var read) && read.GetString() != "None") return true;
        if (m.Security.TryGetProperty("Write", out var write) && write.GetString() != "None") return true;
    }

    return false;
}

// ── Class index for superclass resolution ────────────────────────────────────
var classIndex = dump.Classes.ToDictionary(c => c.Name);

static bool InheritsFrom(string? className, string targetBase, Dictionary<string, ApiClass> index)
{
    var curr = className;
    while (curr != null && curr != "<<<ROOT>>>")
    {
        if (curr == targetBase) return true;
        if (index.TryGetValue(curr, out var cls))
            curr = cls.Superclass;
        else
            break;
    }
    return false;
}

static (string subfolder, string ns) GetRouting(ApiClass cls, Dictionary<string, ApiClass> index)
{
    if (cls.Tags?.Contains("Service") == true)
        return ("Services", "Roblox.Services");
    
    if (InheritsFrom(cls.Name, "BasePart", index))
        return ("Instances/Parts", "Roblox.Instances");
        
    if (InheritsFrom(cls.Name, "GuiObject", index) || InheritsFrom(cls.Name, "GuiBase2d", index))
        return ("Instances/Gui", "Roblox.Instances");
        
    return ("Instances", "Roblox.Instances");
}

var blocklist = new HashSet<string> {
    "AnnotationsService", "ActivityHistoryEventService", "StudioService",
    "StudioData", "DebuggerManager", "ScriptContext", "CoreGui",
    "RobloxPluginGuiService", "PluginGuiService", "Selection",
    "ChangeHistoryService", "TestService", "LogService", "RobloxGui",
    "ScriptEditorService", "TaskScheduler", "RuntimeScriptService",
    "StudioAssetService", "StudioPublishService", "VersionControlService"
};

// ── Generate each class ───────────────────────────────────────────────────────
int written = 0;
int skipped = 0;

foreach (var cls in dump.Classes)
{
    // Class filtering
    if (cls.Tags?.Contains("NotScriptable") == true) { skipped++; continue; }
    if (cls.Tags?.Contains("Deprecated") == true) { skipped++; continue; }
    if (cls.Name.EndsWith("Service") && cls.Tags?.Contains("Service") != true) { skipped++; continue; }
    if (blocklist.Contains(cls.Name)) { skipped++; continue; }

    var routing = GetRouting(cls, classIndex);
    var members = (cls.Members ?? new()).Where(m => !ShouldSkipMember(m)).ToList();

    var superclass = cls.Superclass ?? "Instance";
    var baseClass = superclass == "<<<ROOT>>>" ? "" : $" : {superclass}";

    var sb = new StringBuilder();

    sb.AppendLine("using System;");
    if (NeedsDatatypesUsing(members))
        sb.AppendLine("using Roblox.Datatypes;");
    if (routing.subfolder == "Services")
        sb.AppendLine("using Roblox;");
    sb.AppendLine();
    sb.AppendLine($"namespace {routing.ns};");
    sb.AppendLine();

    if (routing.subfolder == "Services")
        sb.AppendLine("[RobloxService]");

    var isAbstract = cls.Name is "Instance" or "PVInstance" or "BasePart" or "GuiObject"
        or "GuiBase2d" or "LayerCollector" or "ValueBase" ? "abstract " : "";

    sb.AppendLine($"public {isAbstract}class {cls.Name}{baseClass}");
    sb.AppendLine("{");

    var properties  = members.Where(m => m.MemberType == "Property").ToList();
    var functions   = members.Where(m => m.MemberType == "Function").ToList();
    var events      = members.Where(m => m.MemberType == "Event").ToList();
    var callbacks   = members.Where(m => m.MemberType == "Callback").ToList();

    // ── Properties ───────────────────────────────────────────────────────────
    if (properties.Any())
    {
        sb.AppendLine("    // Properties");
        foreach (var prop in properties)
        {
            var typeName = MapType(prop.ValueType?.Name ?? "object", nullable: true);
            var isReadOnly = prop.Tags?.Contains("ReadOnly") == true;
            var needsInit = typeName.EndsWith("?") || typeName == "string" || typeName == "string?";
            var defaultVal = typeName switch
            {
                "string"  => " = null!;",
                "string?" => " = null!;",
                _ when typeName.EndsWith("?") => " = null!;",
                _ => ""
            };
            var getter = isReadOnly ? "{ get; }" : "{ get; set; }";
            sb.AppendLine($"    public {typeName} {SanitizeName(prop.Name)} {getter}{defaultVal}");
        }
        sb.AppendLine();
    }

    // ── Methods ──────────────────────────────────────────────────────────────
    if (functions.Any())
    {
        sb.AppendLine("    // Methods");
        foreach (var func in functions)
        {
            var returnType = MapType(func.ReturnType?.Name ?? "void");
            var parameters = BuildParameters(func.Parameters);
            var body = returnType == "void" ? "{ }" : "=> default!;";
            if (returnType is "Instance" or "Instance?" or "object" or "object?")
                body = "=> null!;";
            sb.AppendLine($"    public {returnType} {SanitizeName(func.Name)}({parameters}) {body}");
        }
        sb.AppendLine();
    }

    // ── Callbacks ────────────────────────────────────────────────────────────
    if (callbacks.Any())
    {
        sb.AppendLine("    // Callbacks");
        foreach (var cb in callbacks)
        {
            var paramTypes = cb.Parameters?.Select(p => MapType(p.Type?.Name ?? "object")).ToList()
                             ?? new List<string>();
            var returnType = MapType(cb.ReturnType?.Name ?? "object");
            var funcType = paramTypes.Count == 0
                ? $"Func<{returnType}>?"
                : $"Func<{string.Join(", ", paramTypes)}, {returnType}>?";
            sb.AppendLine($"    public {funcType} {SanitizeName(cb.Name)} {{ get; set; }}");
        }
        sb.AppendLine();
    }

    // ── Events ───────────────────────────────────────────────────────────────
    if (events.Any())
    {
        sb.AppendLine("    // Events");
        foreach (var evt in events)
        {
            var paramTypes = evt.Parameters?.Select(p => MapType(p.Type?.Name ?? "object")).ToList()
                             ?? new List<string>();
            var actionType = paramTypes.Count == 0
                ? "Action"
                : $"Action<{string.Join(", ", paramTypes)}>";
            sb.AppendLine($"    public event {actionType} {SanitizeName(evt.Name)} = null!;");
        }
    }

    if (!properties.Any() && !functions.Any() && !events.Any() && !callbacks.Any())
        sb.AppendLine("    // (no scriptable members)");

    sb.AppendLine("}");

    var path = Path.Combine(outDir, routing.subfolder, $"{cls.Name}.cs");
    Directory.CreateDirectory(Path.GetDirectoryName(path)!);
    await File.WriteAllTextAsync(path, sb.ToString());
    written++;
}

Console.WriteLine($"Done. Written: {written}, Skipped: {skipped}");

// ── Parameter builder ─────────────────────────────────────────────────────────
static string BuildParameters(List<ApiParameter>? parameters)
{
    if (parameters == null || parameters.Count == 0) return "";
    return string.Join(", ", parameters.Select(p =>
    {
        var type = MapType(p.Type?.Name ?? "object", nullable: true);
        var name = SanitizeName(p.Name ?? "arg");
        var def = p.Default != null ? $" = {MapDefault(p.Default, type)}" : "";
        return $"{type} {name}{def}";
    }));
}

static string SanitizeName(string name)
{
    if (string.IsNullOrEmpty(name)) return "Unknown";
    var sb = new StringBuilder();
    bool capitalizeNext = false;
    foreach (var c in name)
    {
        if (char.IsLetterOrDigit(c))
        {
            sb.Append(capitalizeNext ? char.ToUpper(c) : c);
            capitalizeNext = false;
        }
        else if (c == ' ' || c == '-')
        {
            capitalizeNext = true;
        }
    }
    var clean = sb.ToString();
    return clean switch
    {
        "params"   => "@params",
        "object"   => "@object",
        "event"    => "@event",
        "string"   => "@string",
        "delegate" => "@delegate",
        "override" => "@override",
        "base"     => "@base",
        "virtual"  => "@virtual",
        "default"  => "@default",
        "in"       => "@in",
        "out"      => "@out",
        "ref"      => "@ref",
        _          => clean
    };
}

static string MapDefault(string def, string type) => def switch
{
    "true"  => "true",
    "false" => "false",
    "nil"   => "null",
    "0"     => "0",
    "1"     => "1",
    _       => type.EndsWith("?") ? "null" : "default"
};

// ── JSON model ────────────────────────────────────────────────────────────────
record ApiDump(
    [property: JsonPropertyName("Classes")] List<ApiClass> Classes,
    [property: JsonPropertyName("Enums")]   List<ApiEnum>  Enums
);

record ApiClass(
    [property: JsonPropertyName("Name")]       string         Name,
    [property: JsonPropertyName("Superclass")] string?        Superclass,
    [property: JsonPropertyName("Members")]    List<ApiMember>? Members,
    [property: JsonPropertyName("Tags")]       List<string>?  Tags
);

class ApiMember
{
    [JsonPropertyName("MemberType")] public string              MemberType { get; set; } = "";
    [JsonPropertyName("Name")]        public string              Name       { get; set; } = "";
    [JsonPropertyName("ValueType")]
    [JsonConverter(typeof(ApiTypeRefConverter))]
                                      public ApiTypeRef?         ValueType  { get; set; }
    [JsonPropertyName("ReturnType")]
    [JsonConverter(typeof(ApiTypeRefConverter))]
                                      public ApiTypeRef?         ReturnType { get; set; }
    [JsonPropertyName("Parameters")]  public List<ApiParameter>? Parameters { get; set; }
    [JsonPropertyName("Tags")]        public List<string>?       Tags       { get; set; }
    [JsonPropertyName("Security")]    public JsonElement         Security   { get; set; }
}

record ApiParameter(
    [property: JsonPropertyName("Name")]    string?    Name,
    [property: JsonPropertyName("Type")]    ApiTypeRef? Type,
    [property: JsonPropertyName("Default")] string?    Default
);

class ApiTypeRef
{
    [JsonPropertyName("Name")]     public string? Name     { get; set; }
    [JsonPropertyName("Category")] public string? Category { get; set; }
}


record ApiEnum(
    [property: JsonPropertyName("Name")]  string           Name,
    [property: JsonPropertyName("Items")] List<ApiEnumItem>? Items
);

record ApiEnumItem(
    [property: JsonPropertyName("Name")]  string Name,
    [property: JsonPropertyName("Value")] int    Value
);

class ApiTypeRefConverter : JsonConverter<ApiTypeRef?>
{
    public override ApiTypeRef? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var val = reader.GetString();
            return val is null or "None" ? null : new ApiTypeRef { Name = val, Category = "Primitive" };
        }

        if (reader.TokenType == JsonTokenType.StartObject)
        {
            var result = new ApiTypeRef();
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.TokenType != JsonTokenType.PropertyName) continue;
                var key = reader.GetString();
                reader.Read();
                switch (key)
                {
                    case "Name":     result.Name     = reader.GetString(); break;
                    case "Category": result.Category = reader.GetString(); break;
                    default: reader.Skip(); break;
                }
            }
            return result;
        }

        reader.Skip();
        return null;
    }

    public override void Write(Utf8JsonWriter writer, ApiTypeRef? value, JsonSerializerOptions options)
        => throw new NotImplementedException();
}