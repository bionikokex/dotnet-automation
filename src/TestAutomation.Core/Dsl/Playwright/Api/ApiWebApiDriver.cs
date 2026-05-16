using TestAutomation.Core.Dsl.Playwright.Actions;

namespace TestAutomation.Core.Dsl.Playwright.Api;

/// <summary>
/// WebApi driver домена API.
/// </summary>
public sealed class ApiWebApiDriver : IApiWebApiDriver
{
    private readonly AutomationActor _actor;

    /// <summary>
    /// Создает api driver поверх automation actor.
    /// </summary>
    public ApiWebApiDriver(AutomationActor actor)
    {
        _actor = actor;
    }

    /// <inheritdoc />
    public Task CheckHomePageAvailabilityAsync()
        => _actor.ExecuteAsync(new AssertPlaywrightHomePageAvailableOverApi());
}
