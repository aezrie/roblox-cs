namespace RobloxCs.Compiler.LuauAst;

public record LuaIdentifierExpression(string Name) : LuaNode;
public record LuaLiteralExpression(object Value) : LuaNode;
public record LuaInvocationExpression(LuaNode Target, LuaNode[] Arguments) : LuaNode;
public record LuaMemberAccessExpression(LuaNode Expression, string MemberName, bool UseColon = false) : LuaNode;
