using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Pages;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// Browser action для проверки открытия .NET documentation.
/// </summary>
public sealed class AssertDotNetDocumentationOpened : BrowserAction
{
    /// <summary>
    /// Выполняет проверку URL .NET docs.
    /// </summary>
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => new PlaywrightHomePage(browser).AssertDotNetDocsOpenedAsync(cancellationToken);
}
