using System.Text;
using RobloxCs.Compiler.LuauAst;

namespace RobloxCs.Compiler;

public class Renderer
{
    private readonly StringBuilder _sb = new();
    private int _indent = 0;

    public string Render(LuaNode node)
    {
        Visit(node);
        return _sb.ToString();
    }

    private void Visit(LuaNode node)
    {
        switch (node)
        {
            case LuaBlockStatement block:
                foreach (var stmt in block.Statements) Visit(stmt);
                break;
            case LuaLocalDeclarationStatement local:
                WriteIndent();
                _sb.Append($"local {local.Name}");
                if (local.Initializer != null)
                {
                    _sb.Append(" = ");
                    Visit(local.Initializer);
                }
                _sb.AppendLine();
                break;
            case LuaExpressionStatement exprStmt:
                WriteIndent();
                Visit(exprStmt.Expression);
                _sb.AppendLine();
                break;
            case LuaInvocationExpression invocation:
                Visit(invocation.Target);
                _sb.Append("(");
                _sb.Append(string.Join(", ", invocation.Arguments.Select(RenderToString)));
                _sb.Append(")");
                break;
            case LuaMemberAccessExpression member:
                Visit(member.Expression);
                _sb.Append(member.UseColon ? $":{member.MemberName}" : $".{member.MemberName}"); // Logic for : vs .
                break;
            case LuaIdentifierExpression identifier:
                _sb.Append(identifier.Name);
                break;
            case LuaLiteralExpression literal:
                _sb.Append(literal.Value);
                break;
            case LuaAssignmentExpression assign:
                Visit(assign.Left);
                _sb.Append(" = ");
                Visit(assign.Right);
                break;

            case LuaFunctionExpression func:
                _sb.Append("function(");
                _sb.Append(string.Join(", ", func.Parameters));
                _sb.AppendLine(")");
                _indent++;
                foreach (var stmt in func.Body.Statements) Visit(stmt);
                _indent--;
                WriteIndent();
                _sb.Append("end");
                break;

            case LuaReturnStatement ret:
                WriteIndent();
                _sb.Append("return");
                if (ret.Value != null)
                {
                    _sb.Append(" ");
                    Visit(ret.Value);
                }
                _sb.AppendLine();
                break;

            case LuaBoolExpression b:
                _sb.Append(b.Value ? "true" : "false");
                break;

            case LuaNilExpression:
                _sb.Append("nil");
                break;

        }
    }

    private string RenderToString(LuaNode node)
    {
        var tempRenderer = new Renderer();
        tempRenderer.Visit(node);
        return tempRenderer._sb.ToString();
    }

    private void WriteIndent()
    {
        _sb.Append(new string(' ', _indent * 4));
    }
}
