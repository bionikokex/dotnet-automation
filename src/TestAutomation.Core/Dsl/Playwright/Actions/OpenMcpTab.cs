using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для перехода в таб MCP.
/// </summary>
public sealed class OpenMcpTab : BrowserAction
{
    /// <summary>
    /// Выполняет переход через верхнюю навигацию MCP.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).OpenMcpTabAsync(cancellationToken);
}
