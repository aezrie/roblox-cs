namespace RobloxCs.Compiler.LuauAst;

public record LuaIdentifierExpression(string Name) : LuaNode;
public record LuaLiteralExpression(object Value) : LuaNode;
public record LuaInvocationExpression(LuaNode Target, LuaNode[] Arguments) : LuaNode;
public record LuaMemberAccessExpression(LuaNode Expression, string MemberName, bool UseColon = false) : LuaNode;
public record LuaBinaryExpression(LuaNode Left, string Operator, LuaNode Right) : LuaNode;
public record LuaUnaryExpression(string Operator, LuaNode Operand) : LuaNode;
public record LuaFunctionExpression(List<string> Parameters, LuaBlockStatement Body) : LuaNode;
public record LuaTableConstructorExpression(List<(string? Key, LuaNode Value)> Fields) : LuaNode;
public record LuaIndexExpression(LuaNode Table, LuaNode Key) : LuaNode;
public record LuaNilExpression() : LuaNode;
public record LuaBoolExpression(bool Value) : LuaNode;
