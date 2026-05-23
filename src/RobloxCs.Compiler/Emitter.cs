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
    private string? _lastDeclaredClassName = null;
    private bool _inInstanceMethod = false;

    private readonly List<(string Name, LuaNode Value)> _pendingDeclarations = new();

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

        // Add return for the last declared class/struct if any
        if (_lastDeclaredClassName != null)
        {
            statements.Add(new LuaReturnStatement(new LuaIdentifierExpression(_lastDeclaredClassName)));
        }

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

    private bool IsRobloxStruct(ITypeSymbol? type)
    {
        if (type == null) return false;
        return type.TypeKind == TypeKind.Struct || type.GetAttributes().Any(a => a.AttributeClass?.Name == "RobloxStructAttribute");
    }

    private LuaNode WrapCloneIfStruct(ExpressionSyntax node, LuaNode luaNode)
    {
        var type = _semanticModel.GetTypeInfo(node).Type;
        if (IsRobloxStruct(type))
        {
            // Don't clone literals, new expressions, or with expressions (they are already new/cloned)
            if (node is ObjectCreationExpressionSyntax || node is LiteralExpressionSyntax || node is WithExpressionSyntax)
                return luaNode;

            return new LuaInvocationExpression(
                new LuaMemberAccessExpression(luaNode, "Clone", true),
                new LuaNode[] { });
        }
        return luaNode;
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
                ? WrapCloneIfStruct(variable.Initializer.Value, VisitExpression(variable.Initializer.Value))
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
        var thenBlock = CaptureBlock(() =>
        {
            foreach (var (name, value) in _pendingDeclarations)
            {
                EmitStatement(new LuaLocalDeclarationStatement(name, value));
            }
            _pendingDeclarations.Clear();

            Visit(node.Statement);
        });

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

    public override void VisitSwitchStatement(SwitchStatementSyntax node)
    {
        var expression = VisitExpression(node.Expression);
        
        // We emit switch as a series of if/elseif in Luau
        LuaNode? firstCondition = null;
        LuaBlockStatement? firstBody = null;
        var elseIfs = new List<(LuaNode Condition, LuaBlockStatement Body)>();
        LuaBlockStatement? elseBlock = null;

        foreach (var section in node.Sections)
        {
            foreach (var label in section.Labels)
            {
                LuaNode? condition = null;
                if (label is CaseSwitchLabelSyntax caseLabel)
                {
                    condition = new LuaBinaryExpression(expression, "==", VisitExpression(caseLabel.Value));
                }
                else if (label is CasePatternSwitchLabelSyntax patternLabel)
                {
                    if (patternLabel.Pattern is DeclarationPatternSyntax decl)
                    {
                        var typeSymbol = _semanticModel.GetTypeInfo(decl.Type).Type;
                        if (IsRobloxInstance(typeSymbol))
                        {
                            condition = new LuaInvocationExpression(
                                new LuaMemberAccessExpression(expression, "IsA", true),
                                new[] { new LuaLiteralExpression($"\"{typeSymbol.Name}\"") });
                            
                            if (decl.Designation is SingleVariableDesignationSyntax varDecl)
                            {
                                // We'll handle this by injecting the declaration into the section body
                                // This is a bit simplified; real C# switch has complex scoping
                            }
                        }
                    }
                }

                if (condition != null)
                {
                    var body = CaptureBlock(() =>
                    {
                        // Inject declarations if it was a pattern
                        if (label is CasePatternSwitchLabelSyntax pl && pl.Pattern is DeclarationPatternSyntax d && d.Designation is SingleVariableDesignationSyntax v)
                        {
                            EmitStatement(new LuaLocalDeclarationStatement(v.Identifier.Text, expression));
                        }

                        foreach (var stmt in section.Statements)
                        {
                            if (stmt is BreakStatementSyntax) continue;
                            Visit(stmt);
                        }
                    });

                    if (firstCondition == null)
                    {
                        firstCondition = condition;
                        firstBody = body;
                    }
                    else
                    {
                        elseIfs.Add((condition, body));
                    }
                }
                else if (label is DefaultSwitchLabelSyntax)
                {
                    elseBlock = CaptureBlock(() =>
                    {
                        foreach (var stmt in section.Statements)
                        {
                            if (stmt is BreakStatementSyntax) continue;
                            Visit(stmt);
                        }
                    });
                }
            }
        }

        if (firstCondition != null && firstBody != null)
        {
            EmitStatement(new LuaIfStatement(firstCondition, firstBody, elseIfs, elseBlock));
        }
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node) => VisitTypeDeclaration(node);
    public override void VisitStructDeclaration(StructDeclarationSyntax node) => VisitTypeDeclaration(node);

    private void VisitTypeDeclaration(TypeDeclarationSyntax node)
    {
        var symbol = _semanticModel.GetDeclaredSymbol(node);
        var className = node.Identifier.Text;
        _currentClassName = className;
        _lastDeclaredClassName = className;
        bool isStatic = node.Modifiers.Any(m => m.IsKind(SyntaxKind.StaticKeyword));
        bool isStruct = node.Kind() == SyntaxKind.StructDeclaration || IsRobloxStruct(symbol);

        // local ClassName = {}
        EmitStatement(new LuaLocalDeclarationStatement(className,
            new LuaTableConstructorExpression(new List<(string?, LuaNode)>())));

        if (!isStatic)
        {
            // ClassName.__index = ClassName
            EmitStatement(new LuaAssignmentStatement(
                new LuaMemberAccessExpression(new LuaIdentifierExpression(className), "__index", false),
                new LuaIdentifierExpression(className)));

            if (isStruct)
            {
                // function ClassName:Clone() return setmetatable(table.clone(self), ClassName) end
                var cloneBody = CaptureBlock(() =>
                {
                    EmitStatement(new LuaReturnStatement(
                        new LuaInvocationExpression(
                            new LuaIdentifierExpression("setmetatable"),
                            new LuaNode[]
                            {
                                new LuaInvocationExpression(
                                    new LuaMemberAccessExpression(new LuaIdentifierExpression("table"), "clone", false),
                                    new[] { new LuaIdentifierExpression("self") }),
                                new LuaIdentifierExpression(className)
                            })));
                });
                EmitStatement(new LuaFunctionDeclarationStatement(
                    new LuaMemberAccessExpression(new LuaIdentifierExpression(className), "Clone", true),
                    new List<string>(), cloneBody));
            }

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

        _currentClassName = null;
    }

    private void EmitFieldInitializers(TypeDeclarationSyntax classNode)
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
            AwaitExpressionSyntax awaitExpr               => VisitAwait(awaitExpr),
            IsPatternExpressionSyntax isPattern           => VisitIsPattern(isPattern),
            WithExpressionSyntax withExpr                 => VisitWith(withExpr),
            InterpolatedStringExpressionSyntax interpolated => VisitInterpolatedString(interpolated),
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
                .Select(a => WrapCloneIfStruct(a.Expression, VisitExpression(a.Expression))).ToArray();
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

        // Game.Workspace -> workspace
        if (symbol?.Name == "Workspace" && (symbol.ContainingType?.Name == "Game" || symbol.ContainingType?.ToDisplayString() == "Roblox.Game"))
        {
            return new LuaIdentifierExpression("workspace");
        }

        // Task.WhenAll(t1, t2) -> (custom barrier implementation)
        if (symbol?.Name == "WhenAll" && symbol.ContainingType?.Name == "Task" && symbol.ContainingType.ContainingNamespace?.ToDisplayString() == "System.Threading.Tasks")
        {
            var taskList = node.ArgumentList.Arguments.Select(a => WrapCloneIfStruct(a.Expression, VisitExpression(a.Expression))).ToList();
            
            // For Phase 3, we simply emit the expressions sequentially for now to maintain the yielding flow.
            // This is valid in Luau for yielding functions when wrapped in a block.
            return new LuaBlockStatement(taskList.Select(t => (LuaNode)new LuaExpressionStatement(t)).ToList());
        }

        var target = VisitExpression(node.Expression);
        var arguments = node.ArgumentList.Arguments
            .Select(a => WrapCloneIfStruct(a.Expression, VisitExpression(a.Expression))).ToArray();

        // If this is a Task.WhenAll call that was handled above, it won't reach here 
        // because we return a LuaBlockStatement. 
        // But Roslyn's walker might continue into arguments if we aren't careful.
        // Actually, we are returning from VisitInvocation, so it's fine.

        // Patch colon flag based on receiver type
        if (target is LuaMemberAccessExpression member)
        {
            var receiverType = ResolveReceiverType(node.Expression);
            target = member with { UseColon = ShouldUseColon(receiverType) };
        }

        return new LuaInvocationExpression(target, arguments);
    }

    private LuaNode VisitIsPattern(IsPatternExpressionSyntax node)
    {
        var expression = VisitExpression(node.Expression);
        if (node.Pattern is DeclarationPatternSyntax decl)
        {
            var typeSymbol = _semanticModel.GetTypeInfo(decl.Type).Type;
            if (IsRobloxInstance(typeSymbol))
            { 
                if (decl.Designation is SingleVariableDesignationSyntax varDecl)
                {
                    _pendingDeclarations.Add((varDecl.Identifier.Text, expression));
                }

                return new LuaInvocationExpression(
                    new LuaMemberAccessExpression(expression, "IsA", true),
                    new[] { new LuaLiteralExpression($"\"{typeSymbol.Name}\"") });
            }
        }
        return new LuaLiteralExpression($"--[[UNHANDLED Pattern: {node.Pattern.GetType().Name}]]");
    }

    private LuaNode VisitWith(WithExpressionSyntax node)
    {
        var expression = VisitExpression(node.Expression);

        return new LuaInvocationExpression(
            new LuaFunctionExpression(new List<string> { "_c" }, CaptureBlock(() =>
            {
                foreach (var initializer in node.Initializer.Expressions)
                {
                    if (initializer is AssignmentExpressionSyntax assignment)
                    {
                        var right = VisitExpression(assignment.Right);
                        EmitStatement(new LuaAssignmentStatement(
                            new LuaMemberAccessExpression(new LuaIdentifierExpression("_c"), assignment.Left.ToString(), false),
                            right));
                    }
                }
                EmitStatement(new LuaReturnStatement(new LuaIdentifierExpression("_c")));
            })),
            new[] { new LuaInvocationExpression(new LuaMemberAccessExpression(expression, "Clone", true), new LuaNode[] { }) });
    }

    private LuaNode VisitInterpolatedString(InterpolatedStringExpressionSyntax node)
    {
        var format = "";
        var args = new List<LuaNode>();
        foreach (var content in node.Contents)
        {
            if (content is InterpolatedStringTextSyntax text)
            {
                format += text.TextToken.ValueText;
            }
            else if (content is InterpolationSyntax interp)
            {
                format += "%s";
                args.Add(VisitExpression(interp.Expression));
            }
        }
        
        return new LuaInvocationExpression(
            new LuaMemberAccessExpression(new LuaIdentifierExpression("string"), "format", false),
            new[] { new LuaLiteralExpression($"\"{format}\"") }.Concat(args).ToArray());
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
        var right = WrapCloneIfStruct(node.Right, VisitExpression(node.Right));
        return new LuaAssignmentExpression(left, right);
    }

    private LuaNode VisitLambda(LambdaExpressionSyntax node)
    {
        var isAsync = node.AsyncKeyword.IsKind(SyntaxKind.AsyncKeyword);
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

        if (isAsync)
        {
            var originalBody = body;
            body = new LuaBlockStatement(new List<LuaNode>
            {
                new LuaExpressionStatement(new LuaInvocationExpression(
                    new LuaMemberAccessExpression(new LuaIdentifierExpression("task"), "spawn", false),
                    new[] { new LuaFunctionExpression(new List<string>(), originalBody) }))
            });
        }

        return new LuaFunctionExpression(parameters, body);
    }

    // a?.B -> a and a.B
    // a?.B?.C -> (a and a.B) and a.B.C
    private LuaNode VisitConditionalAccess(ConditionalAccessExpressionSyntax node)
    {
        var rootLua = VisitExpression(node.Expression);
        var result = rootLua;
        var access = rootLua;

        void Process(ExpressionSyntax whenNotNull)
        {
            if (whenNotNull is MemberBindingExpressionSyntax m)
            {
                var receiverType = _semanticModel.GetTypeInfo(access is LuaMemberAccessExpression ? node.Expression : node.Expression).Type; // simplified
                var symbol = _semanticModel.GetSymbolInfo(m).Symbol;
                bool useColon = symbol?.Kind == SymbolKind.Method && ShouldUseColon(symbol.ContainingType);

                access = new LuaMemberAccessExpression(access, m.Name.Identifier.Text, useColon);
                result = new LuaBinaryExpression(result, "and", access);
            }
            else if (whenNotNull is ConditionalAccessExpressionSyntax ca)
            {
                Process(ca.Expression);
                Process(ca.WhenNotNull);
            }
            else if (whenNotNull is InvocationExpressionSyntax invocation)
            {
                var args = invocation.ArgumentList.Arguments.Select(a => VisitExpression(a.Expression)).ToArray();
                Process(invocation.Expression);
                access = new LuaInvocationExpression(access, args);
                // No need to update 'result' here as Process(invocation.Expression) already did it for the member access
            }
        }

        Process(node.WhenNotNull);
        return result;
    }

    private LuaNode VisitAwait(AwaitExpressionSyntax node)
    {
        return VisitExpression(node.Expression);
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
    // new Part() -> Instance.new("Part")
    private LuaNode VisitObjectCreation(ObjectCreationExpressionSyntax node)
    {
        var typeSymbol = _semanticModel.GetTypeInfo(node).Type;
        if (typeSymbol != null && IsRobloxInstance(typeSymbol))
        {
            var args = new List<LuaNode> { new LuaLiteralExpression($"\"{typeSymbol.Name}\"") };
            if (node.ArgumentList is { Arguments.Count: > 0 } argList)
            {
                args.AddRange(argList.Arguments.Select(a => VisitExpression(a.Expression)));
            }
            return new LuaInvocationExpression(
                new LuaMemberAccessExpression(new LuaIdentifierExpression("Instance"), "new", false),
                args.ToArray());
        }

        var typeName = node.Type.ToString();
        var target = new LuaMemberAccessExpression(new LuaIdentifierExpression(typeName), "new", false);
        var creationArgs = (node.ArgumentList?.Arguments ?? default)
            .Select(a => VisitExpression(a.Expression)).ToArray();
        return new LuaInvocationExpression(target, creationArgs);
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
        var symbol = _semanticModel.GetSymbolInfo(node).Symbol;

        // Game.Workspace -> workspace
        if (symbol?.Name == "Workspace" && (symbol.ContainingType?.Name == "Game" || symbol.ContainingType?.ToDisplayString() == "Roblox.Game"))
        {
            return new LuaIdentifierExpression("workspace");
        }

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
        IdentifierNameSyntax id => _semanticModel.GetSymbolInfo(id).Symbol?.ContainingType,
        _ => null
    };

    private bool IsStringType(ExpressionSyntax node) =>
        _semanticModel.GetTypeInfo(node).Type?.SpecialType == SpecialType.System_String;
}
