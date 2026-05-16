using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Api;

/// <summary>
/// DSL домена API.
/// </summary>
public sealed class ApiDsl : DslBase
{
    private readonly IApiBrowserDriver _browserDrivers;
    private readonly IApiWebApiDriver _webApiDrivers;

    /// <summary>
    /// Создает API DSL и подключает driver collection.
    /// </summary>
    public ApiDsl(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(baseDsl, "API")
    {
        _browserDrivers = new ApiBrowserDriverCollection(actor, context, this);
        _webApiDrivers = new ApiWebApiDriverCollection(actor, context, this);
    }

    /// <summary>
    /// Открывает API reference через верхний таб.
    /// </summary>
    public Task OpenReferenceFromTabAsync()
        => _browserDrivers.OpenReferenceFromTabAsync();

    /// <summary>
    /// Проверяет доступность главной страницы через api layer.
    /// </summary>
    public Task CheckHomePageAvailabilityAsync()
        => _webApiDrivers.CheckHomePageAvailabilityAsync();
}
