namespace TestAutomation.Core.Dsl.Infrastructure;

/// <summary>
/// Базовая коллекция drivers для DSL-домена.
/// </summary>
public abstract class DriverCollection<TDriver>
{
    private readonly DslBase _baseDsl;
    private readonly AutomationDriverContext _context;
    private readonly Dictionary<DriverType, TDriver> _drivers = new();

    /// <summary>
    /// Создает коллекцию drivers для конкретного DSL-узла.
    /// </summary>
    protected DriverCollection(AutomationDriverContext context, DslBase baseDsl)
    {
        _context = context;
        _baseDsl = baseDsl;
    }

    /// <summary>
    /// Регистрирует browser driver.
    /// </summary>
    protected void AddInBrowserDriver(TDriver driver)
    {
        _drivers[DriverType.InBrowser] = driver;
    }

    /// <summary>
    /// Регистрирует api driver.
    /// </summary>
    protected void AddWebApiDriver(TDriver driver)
    {
        _drivers[DriverType.WebApi] = driver;
    }

    /// <summary>
    /// Выполняет DSL-действие через текущий driver.
    /// </summary>
    protected Task InvokeAsync(string actionName, Func<TDriver, Task> action)
        => InvokeAsync(actionName, _context.CurrentDriver, action);

    /// <summary>
    /// Выполняет DSL-действие через явно выбранный driver.
    /// </summary>
    protected async Task InvokeAsync(string actionName, DriverType driverType, Func<TDriver, Task> action)
    {
        Console.WriteLine($"Action at {driverType} driver: {_baseDsl.GetFullName()}.{actionName}");
        await action(GetDriver(driverType));
    }

    private TDriver GetDriver(DriverType driverType)
    {
        if (_drivers.TryGetValue(driverType, out var driver))
        {
            return driver;
        }

        throw new InvalidOperationException($"Driver '{driverType}' is not registered for {_baseDsl.GetFullName()}.");
    }
}
