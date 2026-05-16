using TestAutomation.Core.Abstractions;

namespace TestAutomation.Core.Examples.Browser;

public sealed class OpenHomePage : BrowserAction
{
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => browser.GotoAsync("/", cancellationToken);
}
