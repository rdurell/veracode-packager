import path = require('path');
import tl = require('azure-pipelines-task-lib/task');

async function executePackager(): Promise<number> {
    let tool = tl.tool('dotnet')
        .arg(path.join(__dirname, '/tools/net7.0/veracode-package.dll'))
        .arg('pack')
        .arg('--output')
        .arg(tl.getInput('output') || '');

    let platform = tl.getInput('platform') || '';
    if (platform && platform.trim()) {
        tool.arg('--platform').arg(platform);
    }

    tool.arg(tl.getInput('target') || '');

    return await tool.exec();
}

async function run() {
    try {
        tl.setResourcePath(path.join( __dirname, 'task.json'));

        let code = await executePackager();

        if (code != 0) {
            tl.setResult(tl.TaskResult.Failed, tl.loc('FailedMsg'));
        }

        tl.setResult(tl.TaskResult.Succeeded, tl.loc('SucceedMsg'));
    } catch (e) {
        let msg = (e instanceof Error) ? e.message : "Unknown error";
        tl.debug(msg);
        tl.setResult(tl.TaskResult.Failed, msg);
    }
}

run();