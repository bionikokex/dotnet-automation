namespace TestAutomation.Core.Dsl.Infrastructure;

/// <summary>
/// Контекст выбора текущего driver-типа для DSL.
/// </summary>
public sealed class AutomationDriverContext
{
    /// <summary>
    /// Текущий driver. По умолчанию пользовательские шаги выполняются через browser.
    /// </summary>
    public DriverType CurrentDriver { get; private set; } = DriverType.InBrowser;

    /// <summary>
    /// Переключает текущий driver для последующих DSL-вызовов.
    /// </summary>
    public void UseDriver(DriverType driverType)
    {
        CurrentDriver = driverType;
    }
}
