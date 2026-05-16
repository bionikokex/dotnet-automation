using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для проверки CLI introduction.
/// </summary>
public sealed class AssertCliIntroductionOpened : BrowserAction
{
    /// <summary>
    /// Проверяет URL CLI introduction.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).AssertCliIntroductionOpenedAsync(cancellationToken);
}
