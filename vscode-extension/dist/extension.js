/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ([
/* 0 */
/***/ (function(__unused_webpack_module, exports, __webpack_require__) {


var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || (function () {
    var ownKeys = function(o) {
        ownKeys = Object.getOwnPropertyNames || function (o) {
            var ar = [];
            for (var k in o) if (Object.prototype.hasOwnProperty.call(o, k)) ar[ar.length] = k;
            return ar;
        };
        return ownKeys(o);
    };
    return function (mod) {
        if (mod && mod.__esModule) return mod;
        var result = {};
        if (mod != null) for (var k = ownKeys(mod), i = 0; i < k.length; i++) if (k[i] !== "default") __createBinding(result, mod, k[i]);
        __setModuleDefault(result, mod);
        return result;
    };
})();
Object.defineProperty(exports, "__esModule", ({ value: true }));
exports.activate = activate;
exports.deactivate = deactivate;
const vscode = __importStar(__webpack_require__(1));
const cp = __importStar(__webpack_require__(2));
const path = __importStar(__webpack_require__(3));
function activate(context) {
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
function transpile(filePath, outputChannel) {
    const config = vscode.workspace.getConfiguration('roblox-cs');
    let command = config.get('compilerPath') || 'dotnet run --project ${workspaceFolder}/src/RobloxCs.Cli/RobloxCs.Cli.csproj';
    // Replace ${workspaceFolder} if present
    const workspaceFolder = vscode.workspace.getWorkspaceFolder(vscode.Uri.file(filePath));
    if (workspaceFolder) {
        command = command.replace(/\${workspaceFolder}/g, workspaceFolder.uri.fsPath);
    }
    outputChannel.appendLine(`Transpiling ${path.basename(filePath)}...`);
    cp.exec(`${command} "${filePath}"`, (error, stdout, stderr) => {
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
function deactivate() { }


/***/ }),
/* 1 */
/***/ ((module) => {

module.exports = require("vscode");

/***/ }),
/* 2 */
/***/ ((module) => {

module.exports = require("child_process");

/***/ }),
/* 3 */
/***/ ((module) => {

module.exports = require("path");

/***/ })
/******/ 	]);
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module is referenced by other modules so it can't be inlined
/******/ 	var __webpack_exports__ = __webpack_require__(0);
/******/ 	var __webpack_export_target__ = exports;
/******/ 	for(var __webpack_i__ in __webpack_exports__) __webpack_export_target__[__webpack_i__] = __webpack_exports__[__webpack_i__];
/******/ 	if(__webpack_exports__.__esModule) Object.defineProperty(__webpack_export_target__, "__esModule", { value: true });
/******/ 	
/******/ })()
;
//# sourceMappingURL=extension.js.map