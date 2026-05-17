namespace RobloxCs.Compiler.LuauAst;

public record LuaLocalDeclarationStatement(string Name, LuaNode? Initializer) : LuaNode;
public record LuaExpressionStatement(LuaNode Expression) : LuaNode;
public record LuaBlockStatement(List<LuaNode> Statements) : LuaNode;
