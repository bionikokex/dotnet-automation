using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Api;

/// <summary>
/// Коллекция web api drivers домена API.
/// </summary>
public sealed class ApiWebApiDriverCollection : DriverCollection<IApiWebApiDriver>, IApiWebApiDriver
{
    /// <summary>
    /// Создает коллекцию и регистрирует web api driver.
    /// </summary>
    public ApiWebApiDriverCollection(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(context, baseDsl)
    {
        AddWebApiDriver(new ApiWebApiDriver(actor));
    }

    /// <inheritdoc />
    public Task CheckHomePageAvailabilityAsync()
        => InvokeAsync("Проверить главную страницу через API", DriverType.WebApi, driver => driver.CheckHomePageAvailabilityAsync());
}
