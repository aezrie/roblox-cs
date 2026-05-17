using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RobloxCs.Compiler.LuauAst;

namespace RobloxCs.Compiler;

public class Emitter : CSharpSyntaxWalker
{
    private readonly SemanticModel _semanticModel;
    private readonly List<LuaNode> _statements = new();

    public Emitter(SemanticModel semanticModel) : base(SyntaxWalkerDepth.Node)
    {
        _semanticModel = semanticModel;
    }

    public LuaBlockStatement Emit()
    {
        var root = _semanticModel.SyntaxTree.GetRoot();
        Visit(root);
        return new LuaBlockStatement(_statements);
    }

    // Handles top-level statements in Program.cs
    public override void VisitGlobalStatement(GlobalStatementSyntax node)
    {
        base.Visit(node.Statement);
    }

    // Handles: var x = ...; or Players players = ...
    public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
    {
        foreach (var variable in node.Declaration.Variables)
        {
            var name = variable.Identifier.Text;
            LuaNode? initializer = variable.Initializer != null ? VisitExpression(variable.Initializer.Value) : null;
            _statements.Add(new LuaLocalDeclarationStatement(name, initializer));
        }
    }

    // Handles: print("hello");
    public override void VisitExpressionStatement(ExpressionStatementSyntax node)
    {
        var expr = VisitExpression(node.Expression);
        if (expr != null)
        {
            _statements.Add(new LuaExpressionStatement(expr));
        }
    }

    // Dispatches expressions to their specific visitors
    private LuaNode VisitExpression(ExpressionSyntax node)
    {
        return node switch
        {
            InvocationExpressionSyntax invocation => VisitInvocation(invocation),
            LiteralExpressionSyntax literal => VisitLiteral(literal),
            IdentifierNameSyntax identifier => VisitIdentifier(identifier),
            MemberAccessExpressionSyntax memberAccess => VisitMemberAccess(memberAccess),
            _ => new LuaLiteralExpression($"-- UNHANDLED: {node.GetType().Name}")
        };
    }

    private LuaNode VisitInvocation(InvocationExpressionSyntax node)
        {
            var symbol = _semanticModel.GetSymbolInfo(node).Symbol as IMethodSymbol;

            // 1. Map Console.WriteLine to Luau's print()
            if (symbol?.ContainingType?.Name == "Console" && symbol.ContainingType.ContainingNamespace?.ToDisplayString() == "System")
            {
                if (symbol.Name == "WriteLine" || symbol.Name == "Write")
                {
                    var args = node.ArgumentList.Arguments.Select(a => VisitExpression(a.Expression)).ToArray();
                    return new LuaInvocationExpression(new LuaIdentifierExpression("print"), args);
                }
            }

            // 2. Check if it's Game.GetService<T>()
            // Check if it's Game.GetService<T>()
            if (symbol?.Name == "GetService" && symbol.ContainingType?.Name == "Game")
            {
                var serviceType = (INamedTypeSymbol?)symbol.ReturnType;
                return new LuaInvocationExpression(
                    new LuaMemberAccessExpression(new LuaIdentifierExpression("game"), "GetService", true), // <-- ADD true HERE
                    new[] { new LuaLiteralExpression($"\"{serviceType?.Name}\"") }
                );
            }

            // 3. Standard method call
            var target = VisitExpression(node.Expression);
            var arguments = node.ArgumentList.Arguments.Select(a => VisitExpression(a.Expression)).ToArray();
            return new LuaInvocationExpression(target, arguments);
        }

    private LuaNode VisitLiteral(LiteralExpressionSyntax node)
    {
        var value = node.Token.Value;
        return value switch
        {
            string s => new LuaLiteralExpression($"\"{s}\""),
            _ => new LuaLiteralExpression(node.Token.ValueText)
        };
    }

    private LuaNode VisitIdentifier(IdentifierNameSyntax node)
    {
        return new LuaIdentifierExpression(node.Identifier.Text);
    }

    private LuaNode VisitMemberAccess(MemberAccessExpressionSyntax node)
    {
        var expression = VisitExpression(node.Expression);
        return new LuaMemberAccessExpression(expression, node.Name.Identifier.Text);
    }
}
