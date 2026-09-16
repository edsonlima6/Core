const { execSync } = require('child_process');

function runCommand(command) {
    console.log(`Running: ${command}`);
    try {
        const output = execSync(command, { encoding: 'utf8', stdio: 'pipe' });
        return { success: true, output };
    } catch (error) {
        return { success: false, output: error.stdout || error.stderr || error.message };
    }
}

async function main() {
    const results = {};

    // 1. Linting
    console.log('--- Validating Linter ---');
    results.linter = runCommand('dotnet format --verify-no-changes');

    // 2. Tests & Coverage
    console.log('--- Running Tests & Collecting Coverage ---');
    results.tests = runCommand('dotnet test --collect:"XPlat Code Coverage"');

    // Output summary
    console.log('\n=== Review Metrics Summary ===');
    console.log(`Linter: ${results.linter.success ? 'PASSED' : 'FAILED'}`);
    console.log(`Tests: ${results.tests.success ? 'PASSED' : 'FAILED'}`);

    if (!results.linter.success) {
        console.log('\n--- Linter Issues ---');
        console.log(results.linter.output.split('\n').slice(0, 20).join('\n'));
    }

    if (!results.tests.success) {
        console.log('\n--- Test Failures ---');
        console.log(results.tests.output.split('\n').slice(0, 20).join('\n'));
    }
}

main().catch(console.error);
