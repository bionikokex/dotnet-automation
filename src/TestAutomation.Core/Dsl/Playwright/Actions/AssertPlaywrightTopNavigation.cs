using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для проверки верхней навигации сайта.
/// </summary>
public sealed class AssertPlaywrightTopNavigation : BrowserAction
{
    /// <summary>
    /// Выполняет проверку ключевых навигационных ссылок.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).AssertTopNavigationAsync(cancellationToken);
}
