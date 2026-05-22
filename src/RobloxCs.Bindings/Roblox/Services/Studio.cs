using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class Studio : Instance
{
    // Properties
    public object? ActionOnStopSync { get; set; } = null!;
    public Color3 ActiveColor { get; set; }
    public Color3 ActiveHoverOverColor { get; set; }
    public bool AlwaysSaveScriptChanges { get; set; }
    public bool AnimateHoverOver { get; set; }
    public bool AutoCleanEmptyLine { get; set; }
    public bool AutoClosingBrackets { get; set; }
    public bool AutoClosingQuotes { get; set; }
    public bool AutoDeleteClosingBracketsAndQuotes { get; set; }
    public object? AutoIndentRule { get; set; } = null!;
    public bool AutoRecoveryEnabled { get; set; }
    public int AutoRecoveryIntervalMinutes { get; set; }
    public Color3 BackgroundColor { get; set; }
    public object? BasicObjectsDisplayMode { get; set; } = null!;
    public Color3 BoolColor { get; set; }
    public Color3 BracketColor { get; set; }
    public Color3 BuiltInFunctionColor { get; set; }
    public float CameraMouseWheelSpeed { get; set; }
    public float CameraShiftSpeed { get; set; }
    public float CameraSpeed { get; set; }
    public bool CameraZoomToMousePosition { get; set; }
    public bool ClearOutputOnStart { get; set; }
    public bool CommandBarLocalState { get; set; }
    public Color3 CommentColor { get; set; }
    public Color3 CurrentLineHighlightColor { get; set; }
    public Color3 DebuggerCurrentLineColor { get; set; }
    public Color3 DebuggerErrorLineColor { get; set; }
    public bool DeprecatedObjectsShown { get; set; }
    public bool EnableAutocomplete { get; set; }
    public bool EnableCoreScriptDebugger { get; set; }
    public bool EnableHttpSandboxing { get; set; }
    public bool EnableInternalBetaFeatures { get; set; }
    public bool EnableInternalFeatures { get; set; }
    public bool EnableTemporaryTabs { get; set; }
    public bool EnableTemporaryTabsInExplorer { get; set; }
    public Color3 ErrorColor { get; set; }
    public Color3 FindSelectionBackgroundColor { get; set; }
    public object? Font { get; set; } = null!;
    public bool FormatOnPaste { get; set; }
    public bool FormatOnType { get; set; }
    public Color3 FunctionNameColor { get; set; }
    public bool HighlightCurrentLine { get; set; }
    public bool HighlightOccurances { get; set; }
    public Color3 HintColor { get; set; }
    public object? HoverAnimateSpeed { get; set; } = null!;
    public Color3 HoverOverColor { get; set; }
    public bool IndentUsingSpaces { get; set; }
    public Color3 InformationColor { get; set; }
    public Color3 KeywordColor { get; set; }
    public float LineThickness { get; set; }
    public bool LuaDebuggerEnabled { get; set; }
    public Color3 LuauKeywordColor { get; set; }
    public Color3 MatchingWordBackgroundColor { get; set; }
    public int MaximumOutputLines { get; set; }
    public Color3 MenuItemBackgroundColor { get; set; }
    public Color3 MethodColor { get; set; }
    public Color3 NumberColor { get; set; }
    public bool OnlyPlayAudioFromWindowInFocus { get; set; }
    public Color3 OperatorColor { get; set; }
    public object? OutputFont { get; set; } = null!;
    public object? OutputLayoutMode { get; set; } = null!;
    public object? PermissionLevelShown { get; set; } = null!;
    public bool PluginDebuggingEnabled { get; set; }
    public object? PluginsDir { get; set; } = null!;
    public object? PreferredTextSize { get; set; } = null!;
    public Color3 PrimaryTextColor { get; set; }
    public Color3 PropertyColor { get; set; }
    public bool RespectStudioShortcutsWhenGameHasFocus { get; set; }
    public Color3 RulerColor { get; set; }
    public string? Rulers { get; set; } = null!;
    public object? RuntimeUndoBehavior { get; set; } = null!;
    public int ScriptTimeoutLength { get; set; }
    public object? ScriptEditorColorPreset { get; set; } = null!;
    public Color3 ScriptEditorScrollbarBackgroundColor { get; set; }
    public Color3 ScriptEditorScrollbarHandleColor { get; set; }
    public bool ScrollPastLastLine { get; set; }
    public Color3 SecondaryTextColor { get; set; }
    public Color3 SelectColor { get; set; }
    public Color3 SelectHoverColor { get; set; }
    public Color3 SelectedMenuItemBackgroundColor { get; set; }
    public Color3 SelectedTextColor { get; set; }
    public Color3 SelectionBackgroundColor { get; set; }
    public Color3 SelectionColor { get; set; }
    public bool SetPivotOfImportedParts { get; set; }
    public bool ShowCoreGUIInExplorerWhilePlaying { get; set; }
    public bool ShowDiagnosticsBar { get; set; }
    public bool ShowFileSyncService { get; set; }
    public bool ShowHiddenObjectsInExplorer { get; set; }
    public bool ShowHoverOver { get; set; }
    public bool ShowNavigationMesh { get; set; }
    public bool ShowPluginGUIServiceInExplorer { get; set; }
    public bool ShowWhitespace { get; set; }
    public bool ShowPlusButtonOnHoverInExplorer { get; set; }
    public bool SkipClosingBracketsAndQuotes { get; set; }
    public Color3 StringColor { get; set; }
    public Color3 TODOColor { get; set; }
    public int TabWidth { get; set; }
    public Color3 TextColor { get; set; }
    public bool TextWrapping { get; set; }
    public Instance? Theme { get; set; } = null!;
    public Color3 TypeColor { get; set; }
    public Color3 WarningColor { get; set; }
    public Color3 WhitespaceColor { get; set; }
    public Color3 functionColor { get; set; }
    public Color3 localColor { get; set; }
    public Color3 nilColor { get; set; }
    public Color3 selfColor { get; set; }

}
