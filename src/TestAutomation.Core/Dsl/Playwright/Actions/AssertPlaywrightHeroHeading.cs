using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для проверки hero-заголовка главной страницы.
/// </summary>
public sealed class AssertPlaywrightHeroHeading : BrowserAction
{
    /// <summary>
    /// Выполняет проверку hero-заголовка.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).AssertHeroHeadingAsync(cancellationToken);
}
