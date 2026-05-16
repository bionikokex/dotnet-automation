using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Api;

/// <summary>
/// Коллекция browser drivers домена API.
/// </summary>
public sealed class ApiBrowserDriverCollection : DriverCollection<IApiBrowserDriver>, IApiBrowserDriver
{
    /// <summary>
    /// Создает коллекцию и регистрирует browser driver.
    /// </summary>
    public ApiBrowserDriverCollection(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(context, baseDsl)
    {
        AddInBrowserDriver(new ApiInBrowserDriver(actor));
    }

    /// <inheritdoc />
    public Task OpenReferenceFromTabAsync()
        => InvokeAsync("Открыть API reference", DriverType.InBrowser, driver => driver.OpenReferenceFromTabAsync());
}
