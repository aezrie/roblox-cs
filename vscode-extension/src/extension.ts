import * as vscode from 'vscode';
import * as cp from 'child_process';
import * as path from 'path';

export function activate(context: vscode.ExtensionContext) {
    console.log('Roblox-CS extension is now active!');

    const outputChannel = vscode.window.createOutputChannel("Roblox-CS");

    // Register transpile on save
    let onSave = vscode.workspace.onDidSaveTextDocument((document) => {
        if (document.languageId === 'csharp' && document.fileName.endsWith('.cs')) {
            const config = vscode.workspace.getConfiguration('roblox-cs');
            if (config.get('transpileOnSave')) {
                transpile(document.fileName, outputChannel);
            }
        }
    });

    // Register manual transpile command
    let transpileCmd = vscode.commands.registerCommand('roblox-cs.transpile', () => {
        const activeEditor = vscode.window.activeTextEditor;
        if (activeEditor && activeEditor.document.languageId === 'csharp') {
            transpile(activeEditor.document.fileName, outputChannel);
        }
    });

    context.subscriptions.push(onSave, transpileCmd);
}

function transpile(filePath: string, outputChannel: vscode.OutputChannel) {
    const config = vscode.workspace.getConfiguration('roblox-cs');
    let command = config.get<string>('compilerPath') || 'dotnet run --project ${workspaceFolder}/src/RobloxCs.Cli/RobloxCs.Cli.csproj';

    // Replace ${workspaceFolder} if present
    const workspaceFolder = vscode.workspace.getWorkspaceFolder(vscode.Uri.file(filePath));
    if (workspaceFolder) {
        command = command.replace(/\${workspaceFolder}/g, workspaceFolder.uri.fsPath);
    }

    outputChannel.appendLine(`Transpiling ${path.basename(filePath)}...`);
    
    cp.exec(`${command} "${filePath}"`, (error: Error | null, stdout: string, stderr: string) => {
        if (error) {
            outputChannel.appendLine(`Error: ${error.message}`);
            vscode.window.showErrorMessage(`Roblox-CS: Transpilation failed for ${path.basename(filePath)}`);
            return;
        }
        if (stderr) {
            outputChannel.appendLine(`Compiler Warning/Error: ${stderr}`);
        }
        outputChannel.appendLine(stdout);
        outputChannel.appendLine(`Finished transpiling ${path.basename(filePath)}`);
    });
}

export function deactivate() {}
