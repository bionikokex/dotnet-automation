using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для проверки открытия getting started documentation.
/// </summary>
public sealed class AssertGettingStartedDocumentationOpened : BrowserAction
{
    /// <summary>
    /// Выполняет проверку URL docs/intro.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).AssertDocsIntroOpenedAsync(cancellationToken);
}
