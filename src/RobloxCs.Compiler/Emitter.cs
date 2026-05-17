using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RobloxCs.Compiler.LuauAst;

namespace RobloxCs.Compiler;

public class Emitter : CSharpSyntaxWalker
{
    private readonly SemanticModel _semanticModel;
    private readonly Stack<List<LuaNode>> _scopeStack = new();

    private List<LuaNode> CurrentScope => _scopeStack.Peek();

    public Emitter(SemanticModel semanticModel) : base(SyntaxWalkerDepth.Node)
    {
        _semanticModel = semanticModel;
    }

    private void EmitStatement(LuaNode node) => CurrentScope.Add(node);

    private LuaBlockStatement CaptureBlock(Action visit)
    {
        _scopeStack.Push(new List<LuaNode>());
        visit();
        return new LuaBlockStatement(_scopeStack.Pop());
    }

    public LuaBlockStatement Emit()
    {
        _scopeStack.Push(new List<LuaNode>());
        var root = _semanticModel.SyntaxTree.GetRoot();
        Visit(root);
        return new LuaBlockStatement(_scopeStack.Pop());
    }

    // Checks if a type inherits from Roblox.Instances.Instance anywhere in its chain
    private bool IsRobloxInstance(ITypeSymbol? type)
    {
        var current = type;
        while (current != null)
        {
            if (current.Name == "Instance" &&
                current.ContainingNamespace?.ToDisplayString() == "Roblox.Instances")
                return true;
            current = current.BaseType;
        }
        return false;
    }

    // Handles top-level statements
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
            LuaNode? initializer = variable.Initializer != null
                ? VisitExpression(variable.Initializer.Value)
                : null;
            EmitStatement(new LuaLocalDeclarationStatement(name, initializer));
        }
    }

    // Handles expression statements — method calls, event subscriptions etc.
    public override void VisitExpressionStatement(ExpressionStatementSyntax node)
    {
        var expr = VisitExpression(node.Expression);
        if (expr != null)
            EmitStatement(new LuaExpressionStatement(expr));
    }

    // Handles: return expr;
    public override void VisitReturnStatement(ReturnStatementSyntax node)
    {
        var value = node.Expression != null ? VisitExpression(node.Expression) : null;
        EmitStatement(new LuaReturnStatement(value));
    }

    // Handles: if (cond) { } else if (cond2) { } else { }
    public override void VisitIfStatement(IfStatementSyntax node)
    {
        var condition = VisitExpression(node.Condition);
        var thenBlock = CaptureBlock(() => Visit(node.Statement));

        var elseIfs = new List<(LuaNode Condition, LuaBlockStatement Body)>();
        LuaBlockStatement? elseBlock = null;

        var current = node.Else?.Statement;
        while (current is IfStatementSyntax elseIf)
        {
            elseIfs.Add((VisitExpression(elseIf.Condition), CaptureBlock(() => Visit(elseIf.Statement))));
            current = elseIf.Else?.Statement;
        }
        if (current != null)
            elseBlock = CaptureBlock(() => Visit(current));

        EmitStatement(new LuaIfStatement(condition, thenBlock, elseIfs, elseBlock));
    }

    // Handles: foreach (var item in collection) { }
    public override void VisitForEachStatement(ForEachStatementSyntax node)
    {
        var collection = VisitExpression(node.Expression);
        var body = CaptureBlock(() => Visit(node.Statement));
        EmitStatement(new LuaForEachStatement(node.Identifier.Text, collection, body));
    }

    // Handles: while (cond) { }
    public override void VisitWhileStatement(WhileStatementSyntax node)
    {
        var condition = VisitExpression(node.Condition);
        var body = CaptureBlock(() => Visit(node.Statement));
        EmitStatement(new LuaWhileStatement(condition, body));
    }

    // Handles blocks: { stmt1; stmt2; }
    public override void VisitBlock(BlockSyntax node)
    {
        foreach (var stmt in node.Statements)
            Visit(stmt);
    }

    // Dispatches expressions to their specific visitors
    private LuaNode VisitExpression(ExpressionSyntax node)
    {
        return node switch
        {
            InvocationExpressionSyntax invocation             => VisitInvocation(invocation),
            LiteralExpressionSyntax literal                   => VisitLiteral(literal),
            IdentifierNameSyntax identifier                   => VisitIdentifier(identifier),
            MemberAccessExpressionSyntax memberAccess         => VisitMemberAccess(memberAccess),
            AssignmentExpressionSyntax assignment             => VisitAssignment(assignment),
            LambdaExpressionSyntax lambda                     => VisitLambda(lambda),
            BinaryExpressionSyntax binary                     => VisitBinary(binary),
            PrefixUnaryExpressionSyntax prefixUnary           => VisitPrefixUnary(prefixUnary),
            ParenthesizedExpressionSyntax paren               => VisitExpression(paren.Expression),
            ObjectCreationExpressionSyntax objCreate          => VisitObjectCreation(objCreate),
            DefaultExpressionSyntax                           => new LuaNilExpression(),
            _ => new LuaLiteralExpression($"--[[UNHANDLED: {node.GetType().Name}]]")
        };
    }

    private LuaNode VisitInvocation(InvocationExpressionSyntax node)
    {
        var symbol = _semanticModel.GetSymbolInfo(node).Symbol as IMethodSymbol;

        // 1. Map Console.WriteLine / Console.Write to print()
        if (symbol?.ContainingType?.Name == "Console" &&
            symbol.ContainingType.ContainingNamespace?.ToDisplayString() == "System")
        {
            if (symbol.Name == "WriteLine" || symbol.Name == "Write")
            {
                var args = node.ArgumentList.Arguments
                    .Select(a => VisitExpression(a.Expression))
                    .ToArray();
                return new LuaInvocationExpression(new LuaIdentifierExpression("print"), args);
            }
        }

        // 2. Map Game.GetService<T>() to game:GetService("T")
        if (symbol?.Name == "GetService" && symbol.ContainingType?.Name == "Game")
        {
            var serviceType = (INamedTypeSymbol?)symbol.ReturnType;
            return new LuaInvocationExpression(
                new LuaMemberAccessExpression(new LuaIdentifierExpression("game"), "GetService", true),
                new[] { new LuaLiteralExpression($"\"{serviceType?.Name}\"") }
            );
        }

        // 3. Standard method call — colon if target is a Roblox instance
        var target = VisitExpression(node.Expression);
        var arguments = node.ArgumentList.Arguments
            .Select(a => VisitExpression(a.Expression))
            .ToArray();

        // Patch the member access colon flag based on the receiver's type
        if (target is LuaMemberAccessExpression member)
        {
            var receiverType = ResolveReceiverType(node.Expression);
            var useColon = IsRobloxInstance(receiverType);
            target = member with { UseColon = useColon };
        }

        return new LuaInvocationExpression(target, arguments);
    }

    // Handles: players.PlayerAdded += handler  ->  players.PlayerAdded:Connect(handler)
    //          a = b  ->  a = b
    private LuaNode VisitAssignment(AssignmentExpressionSyntax node)
    {
        if (node.Kind() == SyntaxKind.AddAssignmentExpression)
        {
            var symbol = _semanticModel.GetSymbolInfo(node.Left).Symbol;
            if (symbol?.Kind == SymbolKind.Event)
            {
                var eventTarget = VisitExpression(node.Left);
                var handler = VisitExpression(node.Right);
                return new LuaInvocationExpression(
                    new LuaMemberAccessExpression(eventTarget, "Connect", true),
                    new[] { handler }
                );
            }
        }

        // Plain assignment: a = b
        var left = VisitExpression(node.Left);
        var right = VisitExpression(node.Right);
        return new LuaAssignmentExpression(left, right);
    }

    // Handles: () => expr  and  (Player p) => { ... }
    private LuaNode VisitLambda(LambdaExpressionSyntax node)
    {
        var parameters = node switch
        {
            SimpleLambdaExpressionSyntax simple =>
                new List<string> { simple.Parameter.Identifier.Text },
            ParenthesizedLambdaExpressionSyntax paren =>
                paren.ParameterList.Parameters
                    .Select(p => p.Identifier.Text)
                    .ToList(),
            _ => new List<string>()
        };

        var body = node.Body switch
        {
            BlockSyntax block => CaptureBlock(() =>
            {
                foreach (var stmt in block.Statements)
                    Visit(stmt);
            }),
            ExpressionSyntax expr => CaptureBlock(() =>
                EmitStatement(new LuaReturnStatement(VisitExpression(expr)))),
            _ => new LuaBlockStatement(new List<LuaNode>())
        };

        return new LuaFunctionExpression(parameters, body);
    }

    // Handles binary expressions: a + b, a == b, a && b, etc.
    private LuaNode VisitBinary(BinaryExpressionSyntax node)
    {
        var left = VisitExpression(node.Left);
        var right = VisitExpression(node.Right);
        var luaOp = node.Kind() switch
        {
            // String concat: + on strings becomes ..
            SyntaxKind.AddExpression                    => IsStringType(node.Left) || IsStringType(node.Right) ? ".." : "+",
            SyntaxKind.SubtractExpression               => "-",
            SyntaxKind.MultiplyExpression               => "*",
            SyntaxKind.DivideExpression                 => "/",
            SyntaxKind.ModuloExpression                 => "%",
            SyntaxKind.EqualsExpression                 => "==",
            SyntaxKind.NotEqualsExpression              => "~=",
            SyntaxKind.LessThanExpression               => "<",
            SyntaxKind.GreaterThanExpression            => ">",
            SyntaxKind.LessThanOrEqualExpression        => "<=",
            SyntaxKind.GreaterThanOrEqualExpression     => ">=",
            SyntaxKind.LogicalAndExpression             => "and",
            SyntaxKind.LogicalOrExpression              => "or",
            _ => node.OperatorToken.Text
        };
        return new LuaBinaryExpression(left, luaOp, right);
    }

    // Handles prefix unary: !x -> not x, -x -> -x
    private LuaNode VisitPrefixUnary(PrefixUnaryExpressionSyntax node)
    {
        var operand = VisitExpression(node.Operand);
        var luaOp = node.Kind() switch
        {
            SyntaxKind.LogicalNotExpression => "not",
            SyntaxKind.UnaryMinusExpression => "-",
            _ => node.OperatorToken.Text
        };
        return new LuaUnaryExpression(luaOp, operand);
    }

    // Handles: new Vector3(1, 2, 3) -> Vector3.new(1, 2, 3)
    private LuaNode VisitObjectCreation(ObjectCreationExpressionSyntax node)
    {
        var typeName = node.Type.ToString();
        var target = new LuaMemberAccessExpression(new LuaIdentifierExpression(typeName), "new", false);
        var args = (node.ArgumentList?.Arguments ?? default)
            .Select(a => VisitExpression(a.Expression))
            .ToArray();
        return new LuaInvocationExpression(target, args);
    }

    private LuaNode VisitLiteral(LiteralExpressionSyntax node)
    {
        var value = node.Token.Value;
        return value switch
        {
            string s => new LuaLiteralExpression($"\"{s}\""),
            bool b   => new LuaBoolExpression(b),
            null     => new LuaNilExpression(),
            _        => new LuaLiteralExpression(node.Token.ValueText)
        };
    }

    private LuaNode VisitIdentifier(IdentifierNameSyntax node)
    {
        return new LuaIdentifierExpression(node.Identifier.Text);
    }

    // Resolves whether to use colon based on whether the receiver inherits from Instance
    private LuaNode VisitMemberAccess(MemberAccessExpressionSyntax node)
    {
        var expression = VisitExpression(node.Expression);
        var receiverType = _semanticModel.GetTypeInfo(node.Expression).Type;
        var memberSymbol = _semanticModel.GetSymbolInfo(node).Symbol;

        // Only methods use colon syntax in Luau; properties, events, and fields use dot.
        // (For actual invocations, VisitInvocation will re-evaluate and override this flag.)
        var isMethod = memberSymbol?.Kind == SymbolKind.Method;
        var useColon = isMethod && IsRobloxInstance(receiverType);
        return new LuaMemberAccessExpression(expression, node.Name.Identifier.Text, useColon);
    }

    // Resolves the receiver type from an invocation's expression
    private ITypeSymbol? ResolveReceiverType(ExpressionSyntax node)
    {
        return node switch
        {
            MemberAccessExpressionSyntax m => _semanticModel.GetTypeInfo(m.Expression).Type,
            _ => null
        };
    }

    private bool IsStringType(ExpressionSyntax node)
    {
        var type = _semanticModel.GetTypeInfo(node).Type;
        return type?.SpecialType == SpecialType.System_String;
    }
}
