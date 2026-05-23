namespace RobloxCs.Compiler.LuauAst;

public record LuaLocalDeclarationStatement(string Name, LuaNode? Initializer) : LuaNode;
public record LuaExpressionStatement(LuaNode Expression) : LuaNode;
public record LuaBlockStatement(List<LuaNode> Statements) : LuaNode;
public record LuaReturnStatement(LuaNode? Value) : LuaNode;
public record LuaAssignmentStatement(LuaNode Target, LuaNode Value) : LuaNode;

// Named function declaration: function Foo:Bar(params) ... end
// or                          function Foo.Bar(params) ... end
public record LuaFunctionDeclarationStatement(LuaNode Target, List<string> Parameters, LuaBlockStatement Body) : LuaNode;

public record LuaIfStatement(
    LuaNode Condition,
    LuaBlockStatement Then,
    List<(LuaNode Condition, LuaBlockStatement Body)> ElseIfs,
    LuaBlockStatement? Else
) : LuaNode;

public record LuaForEachStatement(
    string ValueName,
    LuaNode Collection,
    LuaBlockStatement Body
) : LuaNode;

public record LuaWhileStatement(LuaNode Condition, LuaBlockStatement Body) : LuaNode;
public record LuaDoStatement(LuaBlockStatement Body) : LuaNode;
public record LuaCommentStatement(string Comment) : LuaNode;


public record LuaNumericForStatement(
    string VarName,
    LuaNode Start,
    LuaNode Limit,
    LuaNode? Step,
    LuaBlockStatement Body
) : LuaNode;
