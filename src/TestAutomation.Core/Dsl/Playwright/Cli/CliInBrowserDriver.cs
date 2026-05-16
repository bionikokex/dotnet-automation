using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Actions;

namespace TestAutomation.Core.Dsl.Playwright.Cli;

/// <summary>
/// Browser driver домена CLI.
/// </summary>
public sealed class CliInBrowserDriver : ICliDriver
{
    private readonly AutomationActor _actor;

    /// <summary>
    /// Создает browser driver поверх automation actor.
    /// </summary>
    public CliInBrowserDriver(AutomationActor actor)
    {
        _actor = actor;
    }

    /// <inheritdoc />
    public Task OpenIntroductionFromTabAsync()
        => _actor.ExecuteAsync(new CompositeAction(
            new OpenPlaywrightHomePage(),
            new OpenCliTab(),
            new AssertCliIntroductionOpened()));
}
