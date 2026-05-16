using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Actions;

namespace TestAutomation.Core.Dsl.Playwright.Api;

/// <summary>
/// Browser driver домена API.
/// </summary>
public sealed class ApiInBrowserDriver : IApiBrowserDriver
{
    private readonly AutomationActor _actor;

    /// <summary>
    /// Создает browser driver поверх automation actor.
    /// </summary>
    public ApiInBrowserDriver(AutomationActor actor)
    {
        _actor = actor;
    }

    /// <inheritdoc />
    public Task OpenReferenceFromTabAsync()
        => _actor.ExecuteAsync(new CompositeAction(
            new OpenPlaywrightHomePage(),
            new OpenApiTab(),
            new AssertApiReferenceOpened()));

}
