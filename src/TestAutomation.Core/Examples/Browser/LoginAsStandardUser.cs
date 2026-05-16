using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Infrastructure.Sessions;

namespace TestAutomation.Core.Examples.Browser;

public sealed class LoginAsStandardUser : BrowserAction
{
    private readonly string _email;
    private readonly string _password;

    public LoginAsStandardUser(string email, string password)
    {
        _email = email;
        _password = password;
    }

    protected override async Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
    {
        await browser.FillAsync("[data-testid=email]", _email, cancellationToken);
        await browser.FillAsync("[data-testid=password]", _password, cancellationToken);
        await browser.ClickAsync("[data-testid=submit]", cancellationToken);
    }
}
