using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для проверки API reference.
/// </summary>
public sealed class AssertApiReferenceOpened : BrowserAction
{
    /// <summary>
    /// Проверяет URL API reference.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).AssertApiReferenceOpenedAsync(cancellationToken);
}
