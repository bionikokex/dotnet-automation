using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для перехода в таб API.
/// </summary>
public sealed class OpenApiTab : BrowserAction
{
    /// <summary>
    /// Выполняет переход через верхнюю навигацию API.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).OpenApiTabAsync(cancellationToken);
}
