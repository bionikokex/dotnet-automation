using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для перехода в getting started documentation.
/// </summary>
public sealed class OpenGettingStartedDocumentation : BrowserAction
{
    /// <summary>
    /// Выполняет переход из hero-блока в docs/intro.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).OpenGettingStartedAsync(cancellationToken);
}
