using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RobloxCs.Compiler.LuauAst;

namespace RobloxCs.Compiler;

public class Emitter : CSharpSyntaxWalker
{
    private readonly SemanticModel _semanticModel;
    private readonly Stack<List<LuaNode>> _scopeStack = new();

    // Maps local service var name -> Roblox service type name (top-level only)
    // e.g. "players" -> "Players" so usages become game.Players
    private readonly Dictionary<string, string> _serviceVariables = new();
    private readonly HashSet<ITypeSymbol> _requiredTypes = new(SymbolEqualityComparer.Default);

    // Class context — set while visiting a class declaration
    private string? _currentClassName = null;
    private bool _inInstanceMethod = false;

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

        var statements = _scopeStack.Pop();

        // Inject requires at the top
        var requires = new List<LuaNode>();
        foreach (var reqType in _requiredTypes)
        {
            var reqNode = GenerateRequireNode(reqType);
            requires.Add(new LuaLocalDeclarationStatement(reqType.Name, reqNode));
        }

        requires.AddRange(statements);
        return new LuaBlockStatement(requires);
    }

    // ── Type helpers ────────────────────────────────────────────────────────

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

    // Instance methods on user-defined classes should also use colon
    private bool IsCurrentClassType(ITypeSymbol? type) =>
        _currentClassName != null && type?.Name == _currentClassName;

    private bool ShouldUseColon(ITypeSymbol? receiverType) =>
        IsRobloxInstance(receiverType) || IsCurrentClassType(receiverType);

    private void RegisterDependency(ITypeSymbol? type)
    {
        if (type == null) return;
        if (type.ContainingNamespace?.ToDisplayString().StartsWith("System") == true) return;
        if (type.ContainingNamespace?.ToDisplayString().StartsWith("Roblox") == true) return;
        if (type.Name == _currentClassName) return;
        if (type.ContainingNamespace == null || type.ContainingNamespace.IsGlobalNamespace) return;

        _requiredTypes.Add(type);
    }

    private LuaNode GenerateRequireNode(ITypeSymbol type)
    {
        var ns = type.ContainingNamespace.ToDisplayString();
        var parts = ns.Split('.');

        LuaNode rootNode;
        int startIndex = 1;

        if (parts[0] == "Server")
        {
            rootNode = new LuaInvocationExpression(
                new LuaMemberAccessExpression(new LuaIdentifierExpression("game"), "GetService", true),
                new[] { new LuaLiteralExpression("\"ServerScriptService\"") });
        }
        else if (parts[0] == "Client")
        {
            var starterPlayer = new LuaInvocationExpression(
                new LuaMemberAccessExpression(new LuaIdentifierExpression("game"), "GetService", true),
                new[] { new LuaLiteralExpression("\"StarterPlayer\"") });
            rootNode = new LuaMemberAccessExpression(starterPlayer, "StarterPlayerScripts", false);
        }
        else if (parts[0] == "Shared")
        {
            rootNode = new LuaInvocationExpression(
                new LuaMemberAccessExpression(new LuaIdentifierExpression("game"), "GetService", true),
                new[] { new LuaLiteralExpression("\"ReplicatedStorage\"") });
        }
        else
        {
            rootNode = new LuaIdentifierExpression("script");
            startIndex = 0;
        }

        LuaNode current = rootNode;
        for (int i = startIndex; i < parts.Length; i++)
        {
            current = new LuaMemberAccessExpression(current, parts[i], false);
        }

        current = new LuaMemberAccessExpression(current, type.Name, false);
        return new LuaInvocationExpression(new LuaIdentifierExpression("require"), new[] { current });
    }

    // ── Statement visitors ──────────────────────────────────────────────────

    public override void VisitGlobalStatement(GlobalStatementSyntax node) =>
        base.Visit(node.Statement);

    public override void VisitBlock(BlockSyntax node)
    {
        foreach (var stmt in node.Statements) Visit(stmt);
    }

    // var x = ...; or Players players = ...
    public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
    {
        foreach (var variable in node.Declaration.Variables)
        {
            var name = variable.Identifier.Text;

            // At top level: detect GetService<T>() and inline as game.ServiceName
            if (_currentClassName == null &&
                variable.Initializer?.Value is InvocationExpressionSyntax initInvoc)
            {
                var sym = _semanticModel.GetSymbolInfo(initInvoc).Symbol as IMethodSymbol;
                if (sym?.Name == "GetService" && sym.ContainingType?.Name == "Game")
                {
                    var serviceType = (INamedTypeSymbol?)sym.ReturnType;
                    if (serviceType != null)
                    {
                        _serviceVariables[name] = serviceType.Name;
                        continue;
                    }
                }
            }

            LuaNode? initializer = variable.Initializer != null
                ? VisitExpression(variable.Initializer.Value)
                : null;
            EmitStatement(new LuaLocalDeclarationStatement(name, initializer));
        }
    }

    public override void VisitExpressionStatement(ExpressionStatementSyntax node)
    {
        var expr = VisitExpression(node.Expression);
        if (expr != null)
            EmitStatement(new LuaExpressionStatement(expr));
    }

    public override void VisitReturnStatement(ReturnStatementSyntax node)
    {
        var value = node.Expression != null ? VisitExpression(node.Expression) : null;
        EmitStatement(new LuaReturnStatement(value));
    }

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

    public override void VisitForEachStatement(ForEachStatementSyntax node)
    {
        var collection = VisitExpression(node.Expression);
        var body = CaptureBlock(() => Visit(node.Statement));
        EmitStatement(new LuaForEachStatement(node.Identifier.Text, collection, body));
    }

    public override void VisitWhileStatement(WhileStatementSyntax node)
    {
        var condition = VisitExpression(node.Condition);
        var body = CaptureBlock(() => Visit(node.Statement));
        EmitStatement(new LuaWhileStatement(condition, body));
    }

    // ── Class / Method visitors ─────────────────────────────────────────────

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        var className = node.Identifier.Text;
        _currentClassName = className;
        bool isStatic = node.Modifiers.Any(m => m.IsKind(SyntaxKind.StaticKeyword));

        // local ClassName = {}
        EmitStatement(new LuaLocalDeclarationStatement(className,
            new LuaTableConstructorExpression(new List<(string?, LuaNode)>())));

        if (!isStatic)
        {
            // ClassName.__index = ClassName
            EmitStatement(new LuaAssignmentStatement(
                new LuaMemberAccessExpression(new LuaIdentifierExpression(className), "__index", false),
                new LuaIdentifierExpression(className)));

            bool hasConstructor = node.Members.OfType<ConstructorDeclarationSyntax>().Any();
            if (!hasConstructor)
            {
                var body = CaptureBlock(() =>
                {
                    EmitStatement(new LuaLocalDeclarationStatement("self",
                        new LuaInvocationExpression(
                            new LuaIdentifierExpression("setmetatable"),
                            new LuaNode[]
                            {
                                new LuaTableConstructorExpression(new List<(string?, LuaNode)>()),
                                new LuaIdentifierExpression(className)
                            })));

                    _inInstanceMethod = true;
                    EmitFieldInitializers(node);
                    _inInstanceMethod = false;

                    EmitStatement(new LuaReturnStatement(new LuaIdentifierExpression("self")));
                });

                var target = new LuaMemberAccessExpression(
                    new LuaIdentifierExpression(className), "new", false);
                EmitStatement(new LuaFunctionDeclarationStatement(target, new List<string>(), body));
            }
        }

        foreach (var member in node.Members)
            Visit(member);

        // return ClassName
        EmitStatement(new LuaReturnStatement(new LuaIdentifierExpression(className)));

        _currentClassName = null;
    }

    private void EmitFieldInitializers(ClassDeclarationSyntax classNode)
    {
        foreach (var member in classNode.Members)
        {
            if (member is FieldDeclarationSyntax field)
            {
                foreach (var variable in field.Declaration.Variables)
                {
                    if (variable.Initializer != null)
                    {
                        var value = VisitExpression(variable.Initializer.Value);
                        EmitStatement(new LuaAssignmentStatement(
                            new LuaMemberAccessExpression(new LuaIdentifierExpression("self"), variable.Identifier.Text, false),
                            value));
                    }
                }
            }
            else if (member is PropertyDeclarationSyntax prop && prop.Initializer != null)
            {
                var value = VisitExpression(prop.Initializer.Value);
                EmitStatement(new LuaAssignmentStatement(
                    new LuaMemberAccessExpression(new LuaIdentifierExpression("self"), prop.Identifier.Text, false),
                    value));
            }
        }
    }

    public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
    {
        var className = _currentClassName!;
        var paramNames = node.ParameterList.Parameters
            .Select(p => p.Identifier.Text).ToList();

        _inInstanceMethod = true;
        var body = CaptureBlock(() =>
        {
            // local self = setmetatable({}, ClassName)
            EmitStatement(new LuaLocalDeclarationStatement("self",
                new LuaInvocationExpression(
                    new LuaIdentifierExpression("setmetatable"),
                    new LuaNode[]
                    {
                        new LuaTableConstructorExpression(new List<(string?, LuaNode)>()),
                        new LuaIdentifierExpression(className)
                    })));

            EmitFieldInitializers((ClassDeclarationSyntax)node.Parent!);

            if (node.Body != null)
                foreach (var stmt in node.Body.Statements) Visit(stmt);

            EmitStatement(new LuaReturnStatement(new LuaIdentifierExpression("self")));
        });
        _inInstanceMethod = false;

        var target = new LuaMemberAccessExpression(
            new LuaIdentifierExpression(className), "new", false);
        EmitStatement(new LuaFunctionDeclarationStatement(target, paramNames, body));
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        if (_currentClassName == null) return;

        var isStatic = node.Modifiers.Any(m => m.IsKind(SyntaxKind.StaticKeyword));
        var methodName = node.Identifier.Text;
        var paramNames = node.ParameterList.Parameters
            .Select(p => p.Identifier.Text).ToList();

        _inInstanceMethod = !isStatic;
        var body = CaptureBlock(() =>
        {
            if (node.Body != null)
                foreach (var stmt in node.Body.Statements) Visit(stmt);
            else if (node.ExpressionBody != null)
            {
                var expr = VisitExpression(node.ExpressionBody.Expression);
                if (expr != null)
                    EmitStatement(new LuaExpressionStatement(expr));
            }
        });
        _inInstanceMethod = false;

        // Instance methods use colon: function ClassName:Method()
        // Static methods use dot:     function ClassName.Method()
        var target = new LuaMemberAccessExpression(
            new LuaIdentifierExpression(_currentClassName), methodName, !isStatic);
        EmitStatement(new LuaFunctionDeclarationStatement(target, paramNames, body));
    }

    // Skip field/property declarations — they're initialised in the constructor
    public override void VisitFieldDeclaration(FieldDeclarationSyntax node) { }
    public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node) { }

    // ── Expression dispatch ─────────────────────────────────────────────────

    private LuaNode VisitExpression(ExpressionSyntax node)
    {
        return node switch
        {
            InvocationExpressionSyntax invocation         => VisitInvocation(invocation),
            LiteralExpressionSyntax literal               => VisitLiteral(literal),
            IdentifierNameSyntax identifier               => VisitIdentifier(identifier),
            MemberAccessExpressionSyntax memberAccess     => VisitMemberAccess(memberAccess),
            AssignmentExpressionSyntax assignment         => VisitAssignment(assignment),
            LambdaExpressionSyntax lambda                 => VisitLambda(lambda),
            BinaryExpressionSyntax binary                 => VisitBinary(binary),
            PrefixUnaryExpressionSyntax prefixUnary       => VisitPrefixUnary(prefixUnary),
            ParenthesizedExpressionSyntax paren           => VisitExpression(paren.Expression),
            ObjectCreationExpressionSyntax objCreate      => VisitObjectCreation(objCreate),
            ConditionalAccessExpressionSyntax condAccess  => VisitConditionalAccess(condAccess),
            ThisExpressionSyntax                          => new LuaIdentifierExpression("self"),
            DefaultExpressionSyntax                       => new LuaNilExpression(),
            _ => new LuaLiteralExpression($"--[[UNHANDLED: {node.GetType().Name}]]")
        };
    }

    private LuaNode VisitInvocation(InvocationExpressionSyntax node)
    {
        var symbol = _semanticModel.GetSymbolInfo(node).Symbol as IMethodSymbol;

        // Console.WriteLine / Console.Write -> print()
        if (symbol?.ContainingType?.Name == "Console" &&
            symbol.ContainingType.ContainingNamespace?.ToDisplayString() == "System" &&
            (symbol.Name == "WriteLine" || symbol.Name == "Write"))
        {
            var args = node.ArgumentList.Arguments
                .Select(a => VisitExpression(a.Expression)).ToArray();
            return new LuaInvocationExpression(new LuaIdentifierExpression("print"), args);
        }

        // Game.GetService<T>() -> game:GetService("T")
        if (symbol?.Name == "GetService" && symbol.ContainingType?.Name == "Game")
        {
            var serviceType = (INamedTypeSymbol?)symbol.ReturnType;
            return new LuaInvocationExpression(
                new LuaMemberAccessExpression(new LuaIdentifierExpression("game"), "GetService", true),
                new[] { new LuaLiteralExpression($"\"{serviceType?.Name}\"") });
        }

        var target = VisitExpression(node.Expression);
        var arguments = node.ArgumentList.Arguments
            .Select(a => VisitExpression(a.Expression)).ToArray();

        // Patch colon flag based on receiver type
        if (target is LuaMemberAccessExpression member)
        {
            var receiverType = ResolveReceiverType(node.Expression);
            target = member with { UseColon = ShouldUseColon(receiverType) };
        }

        return new LuaInvocationExpression(target, arguments);
    }

    private LuaNode VisitAssignment(AssignmentExpressionSyntax node)
    {
        if (node.Kind() == SyntaxKind.AddAssignmentExpression)
        {
            var symbol = _semanticModel.GetSymbolInfo(node.Left).Symbol;
            if (symbol?.Kind == SymbolKind.Event)
            {
                var eventTarget = VisitExpression(node.Left);
                var handler = VisitExpression(node.Right);

                // Wrap instance method references in a closure: function(...) return self:Method(...) end
                if (handler is LuaMemberAccessExpression { UseColon: true } memberAccess)
                {
                    var parameters = new List<string> { "..." };
                    var body = new LuaBlockStatement(new List<LuaNode>
                    {
                        new LuaReturnStatement(
                            new LuaInvocationExpression(memberAccess, new[] { new LuaIdentifierExpression("...") })
                        )
                    });
                    handler = new LuaFunctionExpression(parameters, body);
                }

                return new LuaInvocationExpression(
                    new LuaMemberAccessExpression(eventTarget, "Connect", true),
                    new[] { handler });
            }
        }

        var left = VisitExpression(node.Left);
        var right = VisitExpression(node.Right);
        return new LuaAssignmentExpression(left, right);
    }

    private LuaNode VisitLambda(LambdaExpressionSyntax node)
    {
        var parameters = node switch
        {
            SimpleLambdaExpressionSyntax simple =>
                new List<string> { simple.Parameter.Identifier.Text },
            ParenthesizedLambdaExpressionSyntax paren =>
                paren.ParameterList.Parameters.Select(p => p.Identifier.Text).ToList(),
            _ => new List<string>()
        };

        var body = node.Body switch
        {
            BlockSyntax block => CaptureBlock(() =>
            {
                foreach (var stmt in block.Statements) Visit(stmt);
            }),
            ExpressionSyntax expr => CaptureBlock(() =>
                EmitStatement(new LuaReturnStatement(VisitExpression(expr)))),
            _ => new LuaBlockStatement(new List<LuaNode>())
        };

        return new LuaFunctionExpression(parameters, body);
    }

    // a?.B -> a and a.B
    // a?.B?.C -> (a and a.B) and a.B.C
    private LuaNode VisitConditionalAccess(ConditionalAccessExpressionSyntax node)
    {
        var members = new List<string>();
        ExpressionSyntax root = node;
        while (root is ConditionalAccessExpressionSyntax ca)
        {
            if (ca.WhenNotNull is MemberBindingExpressionSyntax binding)
                members.Insert(0, binding.Name.Identifier.Text);
            root = ca.Expression;
        }

        var baseExpr = VisitExpression(root);
        LuaNode current = baseExpr;
        LuaNode result = baseExpr;
        foreach (var member in members)
        {
            current = new LuaMemberAccessExpression(current, member, false);
            result = new LuaBinaryExpression(result, "and", current);
        }
        return result;
    }

    private LuaNode VisitBinary(BinaryExpressionSyntax node)
    {
        var left = VisitExpression(node.Left);
        var right = VisitExpression(node.Right);
        var luaOp = node.Kind() switch
        {
            SyntaxKind.AddExpression              => IsStringType(node.Left) || IsStringType(node.Right) ? ".." : "+",
            SyntaxKind.SubtractExpression         => "-",
            SyntaxKind.MultiplyExpression         => "*",
            SyntaxKind.DivideExpression           => "/",
            SyntaxKind.ModuloExpression           => "%",
            SyntaxKind.EqualsExpression           => "==",
            SyntaxKind.NotEqualsExpression        => "~=",
            SyntaxKind.LessThanExpression         => "<",
            SyntaxKind.GreaterThanExpression      => ">",
            SyntaxKind.LessThanOrEqualExpression  => "<=",
            SyntaxKind.GreaterThanOrEqualExpression => ">=",
            SyntaxKind.LogicalAndExpression       => "and",
            SyntaxKind.LogicalOrExpression        => "or",
            SyntaxKind.CoalesceExpression         => "or",
            _ => node.OperatorToken.Text
        };
        return new LuaBinaryExpression(left, luaOp, right);
    }

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

    // new Vector3(1,2,3) -> Vector3.new(1,2,3)
    // new MyClass() -> MyClass.new()
    private LuaNode VisitObjectCreation(ObjectCreationExpressionSyntax node)
    {
        var typeName = node.Type.ToString();
        var target = new LuaMemberAccessExpression(new LuaIdentifierExpression(typeName), "new", false);
        var args = (node.ArgumentList?.Arguments ?? default)
            .Select(a => VisitExpression(a.Expression)).ToArray();
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
        var symbol = _semanticModel.GetSymbolInfo(node).Symbol;

        if (symbol is INamedTypeSymbol namedType)
        {
            RegisterDependency(namedType);
        }
        else if (symbol is IMethodSymbol methodSymbol && methodSymbol.IsStatic)
        {
            RegisterDependency(methodSymbol.ContainingType);
        }

        // Service variable inlining (top-level only, not inside classes)
        if (_currentClassName == null && _serviceVariables.TryGetValue(name, out var serviceName))
            return new LuaMemberAccessExpression(new LuaIdentifierExpression("game"), serviceName, false);

        // Inside instance method: implicit field/property/method access -> self.name or self:name
        if (_inInstanceMethod)
        {
            if ((symbol?.Kind == SymbolKind.Field || symbol?.Kind == SymbolKind.Property || symbol?.Kind == SymbolKind.Method) &&
                symbol.ContainingType?.Name == _currentClassName)
            {
                bool useColon = symbol.Kind == SymbolKind.Method && !((IMethodSymbol)symbol).IsStatic;
                return new LuaMemberAccessExpression(new LuaIdentifierExpression("self"), name, useColon);
            }
        }

        return new LuaIdentifierExpression(name);
    }

    private LuaNode VisitMemberAccess(MemberAccessExpressionSyntax node)
    {
        var expression = VisitExpression(node.Expression);
        var receiverType = _semanticModel.GetTypeInfo(node.Expression).Type;
        var memberSymbol = _semanticModel.GetSymbolInfo(node).Symbol;

        var isMethod = memberSymbol?.Kind == SymbolKind.Method;
        var useColon = isMethod && ShouldUseColon(receiverType);
        return new LuaMemberAccessExpression(expression, node.Name.Identifier.Text, useColon);
    }

    private ITypeSymbol? ResolveReceiverType(ExpressionSyntax node) => node switch
    {
        MemberAccessExpressionSyntax m => _semanticModel.GetTypeInfo(m.Expression).Type,
        _ => null
    };

    private bool IsStringType(ExpressionSyntax node) =>
        _semanticModel.GetTypeInfo(node).Type?.SpecialType == SpecialType.System_String;
}
