using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RobloxCs.Compiler.LuauAst;

namespace RobloxCs.Compiler;

public class Emitter : CSharpSyntaxWalker
{
    private readonly SemanticModel _semanticModel;
    private readonly Stack<List<LuaNode>> _scopeStack = new();
    // Maps local variable name -> Roblox service type name for GetService<T>() assignments
    // e.g. "players" -> "Players" so usages become game.Players instead of a local var
    private readonly Dictionary<string, string> _serviceVariables = new();

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

            // Detect: SomeService x = Game.GetService<SomeService>();
            // Instead of emitting a local variable, record the mapping so that
            // usages of `x` are inlined as `game.SomeService` everywhere.
            if (variable.Initializer?.Value is InvocationExpressionSyntax initInvoc)
            {
                var sym = _semanticModel.GetSymbolInfo(initInvoc).Symbol as IMethodSymbol;
                if (sym?.Name == "GetService" && sym.ContainingType?.Name == "Game")
                {
                    var serviceType = (INamedTypeSymbol?)sym.ReturnType;
                    if (serviceType != null)
                    {
                        _serviceVariables[name] = serviceType.Name;
                        continue; // skip emitting the local declaration
                    }
                }
            }

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
            CastExpressionSyntax cast                         => VisitExpression(cast.Expression),
            ObjectCreationExpressionSyntax objCreate          => VisitObjectCreation(objCreate),
            ConditionalAccessExpressionSyntax condAccess      => VisitConditionalAccess(condAccess),
            InterpolatedStringExpressionSyntax interpolated => VisitInterpolatedString(interpolated),
            DefaultExpressionSyntax                           => new LuaNilExpression(),
            _ => new LuaLiteralExpression($"--[[UNHANDLED: {node.GetType().Name}]]")
        };
    }


    // Handles: a?.B  -> a and a.B
    //          a?.B?.C -> (a and a.B) and a.B.C  (safe: only reaches a.B.C when a.B is truthy)
    private LuaNode VisitConditionalAccess(ConditionalAccessExpressionSyntax node)
    {
        // Flatten the chain: collect member names from innermost to outermost
        var members = new List<string>();
        ExpressionSyntax root = node;
        while (root is ConditionalAccessExpressionSyntax ca)
        {
            if (ca.WhenNotNull is MemberBindingExpressionSyntax binding)
                members.Insert(0, binding.Name.Identifier.Text);
            root = ca.Expression;
        }

        // root is the base receiver (e.g., `player`)
        var baseExpr = VisitExpression(root);

        // Build: base and base.M1 and base.M1.M2 ...
        // Each step: current = previous.Member; result = result and current
        LuaNode current = baseExpr;
        LuaNode result = baseExpr;
        foreach (var member in members)
        {
            current = new LuaMemberAccessExpression(current, member, false);
            result = new LuaBinaryExpression(result, "and", current);
        }
        return result;
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

        // -=  on events -> store connection and call :Disconnect()
        // We emit: eventTarget:Connect(handler) normally on +=
        // For -= we emit a disconnect call if the symbol is an event
        if (node.Kind() == SyntaxKind.SubtractAssignmentExpression)
        {
            var symbol = _semanticModel.GetSymbolInfo(node.Left).Symbol;
            if (symbol?.Kind == SymbolKind.Event)
            {
                // Emit: connectionVar:Disconnect()
                // The user is expected to store the connection in a variable
                var connVar = VisitExpression(node.Right);
                return new LuaInvocationExpression(
                    new LuaMemberAccessExpression(connVar, "Disconnect", true),
                    Array.Empty<LuaNode>()
                );
            }
        }

        var left = VisitExpression(node.Left);
        var right = VisitExpression(node.Right);
        return new LuaAssignmentExpression(left, right);
    }

    // Handles: $"Hello {name} you have {health} hp"
    // -> "Hello " .. tostring(name) .. " you have " .. tostring(health) .. " hp"
    private LuaNode VisitInterpolatedString(InterpolatedStringExpressionSyntax node)
    {
        var parts = new List<LuaNode>();

        foreach (var content in node.Contents)
        {
            switch (content)
            {
                case InterpolatedStringTextSyntax text:
                    var raw = text.TextToken.ValueText;
                    if (!string.IsNullOrEmpty(raw))
                        parts.Add(new LuaLiteralExpression($"\"{raw}\""));
                    break;

                case InterpolationSyntax interpolation:
                    var expr = VisitExpression(interpolation.Expression);
                    var exprType = _semanticModel.GetTypeInfo(interpolation.Expression).Type;

                    // Strings don't need tostring(), everything else does
                    var isString = exprType?.SpecialType == SpecialType.System_String;
                    var part = isString
                        ? expr
                        : new LuaInvocationExpression(
                            new LuaIdentifierExpression("tostring"),
                            new[] { expr });
                    parts.Add(part);
                    break;
            }
        }

        // Fold parts into: a .. b .. c
        if (parts.Count == 0) return new LuaLiteralExpression("\"\"");
        if (parts.Count == 1) return parts[0];

        LuaNode result = parts[0];
        for (int i = 1; i < parts.Count; i++)
            result = new LuaBinaryExpression(result, "..", parts[i]);

        return result;
    }

    // Handles: for (int i = 0; i < 10; i++) -> for i = 0, 9 do
    // Handles: for (int i = 0; i < 10; i += 2) -> for i = 0, 9, 2 do
    public override void VisitForStatement(ForStatementSyntax node)
    {
        // Extract loop variable name and start value
        var varName = node.Declaration?.Variables.FirstOrDefault()?.Identifier.Text ?? "i";
        var startExpr = node.Declaration?.Variables.FirstOrDefault()?.Initializer?.Value;
        var start = startExpr != null ? VisitExpression(startExpr) : new LuaLiteralExpression("0");

        // Extract limit from condition: i < n -> limit = n - 1, i <= n -> limit = n
        LuaNode limit = new LuaLiteralExpression("0");
        if (node.Condition is BinaryExpressionSyntax cond)
        {
            var limitExpr = VisitExpression(cond.Right);
            limit = cond.Kind() switch
            {
                // i < n  -> for i = start, n - 1
                SyntaxKind.LessThanExpression =>
                    new LuaBinaryExpression(limitExpr, "-", new LuaLiteralExpression("1")),
                // i <= n -> for i = start, n
                SyntaxKind.LessThanOrEqualExpression => limitExpr,
                // i > n  -> for i = start, n + 1 (descending)
                SyntaxKind.GreaterThanExpression =>
                    new LuaBinaryExpression(limitExpr, "+", new LuaLiteralExpression("1")),
                // i >= n -> for i = start, n (descending)
                SyntaxKind.GreaterThanOrEqualExpression => limitExpr,
                _ => limitExpr
            };
        }

        // Extract step from incrementor: i++ -> 1, i-- -> -1, i += n -> n, i -= n -> -n
        LuaNode? step = null;
        var incrementor = node.Incrementors.FirstOrDefault();
        if (incrementor != null)
        {
            step = incrementor switch
            {
                PostfixUnaryExpressionSyntax { RawKind: (int)SyntaxKind.PostIncrementExpression } => null, // default step 1, omit
                PostfixUnaryExpressionSyntax { RawKind: (int)SyntaxKind.PostDecrementExpression } =>
                    new LuaLiteralExpression("-1"),
                AssignmentExpressionSyntax { RawKind: (int)SyntaxKind.AddAssignmentExpression } asgn =>
                    VisitExpression(asgn.Right),
                AssignmentExpressionSyntax { RawKind: (int)SyntaxKind.SubtractAssignmentExpression } asgn =>
                    new LuaUnaryExpression("-", VisitExpression(asgn.Right)),
                _ => null
            };
        }

        var body = CaptureBlock(() => Visit(node.Statement));
        EmitStatement(new LuaNumericForStatement(varName, start, limit, step, body));
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
            // ?? (null-coalescing) maps to `or` in Luau: a ?? b -> a or b
            SyntaxKind.CoalesceExpression               => "or",
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
        var name = node.Identifier.Text;
        // If this identifier was a GetService<T>() variable, inline it as game.ServiceName
        if (_serviceVariables.TryGetValue(name, out var serviceName))
            return new LuaMemberAccessExpression(new LuaIdentifierExpression("game"), serviceName, false);
        return new LuaIdentifierExpression(name);
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
