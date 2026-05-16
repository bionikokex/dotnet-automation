using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для перехода в .NET documentation.
/// </summary>
public sealed class OpenDotNetDocumentation : BrowserAction
{
    /// <summary>
    /// Выполняет переход в раздел .NET docs.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).OpenDotNetDocumentationAsync(cancellationToken);
}
