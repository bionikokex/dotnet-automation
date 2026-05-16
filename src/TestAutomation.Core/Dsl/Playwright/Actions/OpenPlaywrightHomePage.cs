using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action, открывающий главную страницу playwright.dev.
/// </summary>
public sealed class OpenPlaywrightHomePage : BrowserAction
{
    /// <summary>
    /// Выполняет переход на домашнюю страницу.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).OpenAsync(cancellationToken);
}
