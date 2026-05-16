using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Infrastructure.Sessions;

namespace TestAutomation.Core.Examples.Browser;

public sealed class OpenHomePage : BrowserAction
{
    protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
        => browser.GotoAsync("/", cancellationToken);
}
