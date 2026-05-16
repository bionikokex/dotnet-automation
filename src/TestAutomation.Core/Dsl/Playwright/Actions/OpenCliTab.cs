using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для перехода в таб CLI.
/// </summary>
public sealed class OpenCliTab : BrowserAction
{
    /// <summary>
    /// Выполняет переход через верхнюю навигацию CLI.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).OpenCliTabAsync(cancellationToken);
}
