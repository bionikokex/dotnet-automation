namespace TestAutomation.Core.Infrastructure.Drivers;

/// <summary>
/// Stack драйверов, предоставляющий доступ к паре (UIDriver, ApiDriver).
/// </summary>
public sealed class DriverStack
{
    private readonly UIDriver _uiDriver;
    private readonly ApiDriver _apiDriver;

    /// <summary>
    /// Создает стек драйверов с UI и API драйверами.
    /// </summary>
    public DriverStack(UIDriver uiDriver, ApiDriver apiDriver)
    {
        _uiDriver = uiDriver;
        _apiDriver = apiDriver;
    }

    /// <summary>
    /// UI драйвер для браузерных действий.
    /// </summary>
    public UIDriver UI => _uiDriver;

    /// <summary>
    /// API драйвер для HTTP-действий.
    /// </summary>
    public ApiDriver Api => _apiDriver;
}
