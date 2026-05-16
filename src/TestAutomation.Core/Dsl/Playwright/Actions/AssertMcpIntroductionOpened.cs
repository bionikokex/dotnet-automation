using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для проверки MCP introduction.
/// </summary>
public sealed class AssertMcpIntroductionOpened : BrowserAction
{
    /// <summary>
    /// Проверяет URL MCP introduction.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).AssertMcpIntroductionOpenedAsync(cancellationToken);
}
