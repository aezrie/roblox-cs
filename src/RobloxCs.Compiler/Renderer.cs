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

            case LuaAssignmentStatement assignStmt:
                WriteIndent();
                Visit(assignStmt.Target);
                _sb.Append(" = ");
                Visit(assignStmt.Value);
                _sb.AppendLine();
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

            // ── Named function declaration ───────────────────────────────────
            case LuaFunctionDeclarationStatement funcDecl:
                WriteIndent();
                _sb.Append("function ");
                Visit(funcDecl.Target);
                _sb.Append("(");
                _sb.Append(string.Join(", ", funcDecl.Parameters));
                _sb.AppendLine(")");
                _indent++;
                foreach (var s in funcDecl.Body.Statements) Visit(s);
                _indent--;
                WriteIndent();
                _sb.AppendLine("end");
                break;


            case LuaIfStatement ifStmt:
                WriteIndent();
                _sb.Append("if ");
                Visit(ifStmt.Condition);
                _sb.AppendLine(" then");
                _indent++;
                foreach (var stmt in ifStmt.Then.Statements) Visit(stmt);
                _indent--;
                foreach (var (cond, body) in ifStmt.ElseIfs)
                {
                    WriteIndent();
                    _sb.Append("elseif ");
                    Visit(cond);
                    _sb.AppendLine(" then");
                    _indent++;
                    foreach (var s in body.Statements) Visit(s);
                    _indent--;
                }
                if (ifStmt.Else != null)
                {
                    WriteIndent();
                    _sb.AppendLine("else");
                    _indent++;
                    foreach (var s in ifStmt.Else.Statements) Visit(s);
                    _indent--;
                }
                WriteIndent();
                _sb.AppendLine("end");
                break;

            // ── for _, item in collection do ────────────────────────────────
            case LuaForEachStatement forEach:
                WriteIndent();
                _sb.Append($"for _, {forEach.ValueName} in ");
                Visit(forEach.Collection);
                _sb.AppendLine(" do");
                _indent++;
                foreach (var s in forEach.Body.Statements) Visit(s);
                _indent--;
                WriteIndent();
                _sb.AppendLine("end");
                break;

            case LuaNumericForStatement numFor:
                WriteIndent();
                _sb.Append($"for {numFor.VarName} = ");
                Visit(numFor.Start);
                _sb.Append(", ");
                Visit(numFor.Limit);
                if (numFor.Step != null)
                {
                    _sb.Append(", ");
                    Visit(numFor.Step);
                }
                _sb.AppendLine(" do");
                _indent++;
                foreach (var s in numFor.Body.Statements) Visit(s);
                _indent--;
                WriteIndent();
                _sb.AppendLine("end");
                break;

            // String interpolation folds to .. chains, already handled by LuaBinaryExpression
            // but if parts need grouping we render them directly
            case LuaStringInterpolationExpression interp:
                for (int i = 0; i < interp.Parts.Count; i++)
                {
                    if (i > 0) _sb.Append(" .. ");
                    Visit(interp.Parts[i]);
                }
                break;


            // ── while cond do ───────────────────────────────────────────────
            case LuaWhileStatement whileStmt:
                WriteIndent();
                _sb.Append("while ");
                Visit(whileStmt.Condition);
                _sb.AppendLine(" do");
                _indent++;
                foreach (var s in whileStmt.Body.Statements) Visit(s);
                _indent--;
                WriteIndent();
                _sb.AppendLine("end");
                break;

            // ── Expressions ─────────────────────────────────────────────────
            case LuaInvocationExpression invocation:
                Visit(invocation.Target);
                _sb.Append("(");
                _sb.Append(string.Join(", ", invocation.Arguments.Select(RenderToString)));
                _sb.Append(")");
                break;

            case LuaMemberAccessExpression member:
                Visit(member.Expression);
                _sb.Append(member.UseColon ? $":{member.MemberName}" : $".{member.MemberName}");
                break;

            case LuaIdentifierExpression identifier:
                _sb.Append(identifier.Name);
                break;

            case LuaLiteralExpression literal:
                _sb.Append(literal.Value);
                break;

            case LuaBoolExpression b:
                _sb.Append(b.Value ? "true" : "false");
                break;

            case LuaNilExpression:
                _sb.Append("nil");
                break;

            case LuaAssignmentExpression assign:
                Visit(assign.Left);
                _sb.Append(" = ");
                Visit(assign.Right);
                break;

            case LuaBinaryExpression binary:
                Visit(binary.Left);
                _sb.Append($" {binary.Operator} ");
                Visit(binary.Right);
                break;

            case LuaUnaryExpression unary:
                // "not" needs a space; "-" doesn't
                _sb.Append(unary.Operator == "not" ? "not " : unary.Operator);
                Visit(unary.Operand);
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

            case LuaTableConstructorExpression table:
                _sb.Append("{");
                var fields = table.Fields;
                if (fields.Count > 0)
                {
                    _sb.AppendLine();
                    _indent++;
                    foreach (var (key, value) in fields)
                    {
                        WriteIndent();
                        if (key != null) _sb.Append($"{key} = ");
                        Visit(value);
                        _sb.AppendLine(",");
                    }
                    _indent--;
                    WriteIndent();
                }
                _sb.Append("}");
                break;

            case LuaIndexExpression index:
                Visit(index.Table);
                _sb.Append("[");
                Visit(index.Key);
                _sb.Append("]");
                break;

            default:
                _sb.Append($"--[[UNRENDERED: {node.GetType().Name}]]");
                break;
        }
    }

    private string RenderToString(LuaNode node)
    {
        var tempRenderer = new Renderer();
        tempRenderer._indent = _indent;
        tempRenderer.Visit(node);
        return tempRenderer._sb.ToString();
    }

    private void WriteIndent()
    {
        _sb.Append(new string(' ', _indent * 4));
    }
}
