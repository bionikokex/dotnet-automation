using TestAutomation.Core.Infrastructure.Drivers;
using TestAutomation.Core.Infrastructure.Dsl;

namespace TestAutomation.Core.Dsl.Api;

/// <summary>
/// DSL домена API.
/// </summary>
public sealed class ApiDsl : DslBase
{
    private readonly DriverStack _drivers;

    /// <summary>
    /// Создает API DSL с доступом к стеку драйверов.
    /// </summary>
    public ApiDsl(DriverStack drivers, DslBase baseDsl)
        : base(baseDsl, "API")
    {
        _drivers = drivers;
    }

    /// <summary>
    /// Открывает API reference через верхний таб.
    /// </summary>
    public async Task OpenReferenceFromTabAsync()
    {
        var ui = _drivers.UI;
        await ui.GotoAsync("/");
        await ui.ClickAsync("nav a:has-text(\"API\")");
        await ui.AssertUrlContainsAsync("/docs/api/class-playwright");
    }

    /// <summary>
    /// Проверяет доступность главной страницы через api layer.
    /// </summary>
    public async Task CheckHomePageAvailabilityAsync()
    {
        var api = _drivers.Api;
        var response = await api.GetAsync("/");
        
        if (response.StatusCode is < 200 or >= 300)
        {
            throw new InvalidOperationException($"Home page request failed with status {response.StatusCode}.");
        }

        if (!response.Body.Contains("Fast and reliable end-to-end testing for modern web apps", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Home page response body does not contain the expected hero text.");
        }
    }
}
