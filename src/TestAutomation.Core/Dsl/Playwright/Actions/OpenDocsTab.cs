using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для перехода в таб Docs.
/// </summary>
public sealed class OpenDocsTab : BrowserAction
{
    /// <summary>
    /// Выполняет переход через верхнюю навигацию Docs.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).OpenDocsTabAsync(cancellationToken);
}
