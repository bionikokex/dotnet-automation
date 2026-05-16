using Microsoft.Playwright;

namespace TestAutomation.Core.Infrastructure.Runtime;

/// <summary>
/// Options для настройки Automation Runtime.
/// </summary>
public sealed class AutomationOptions
{
    /// <summary>
    /// Базовый URL для browser операций.
    /// </summary>
    public string BaseUrl { get; set; } = "https://playwright.dev";

    /// <summary>
    /// Настройки для Playwright browser.
    /// </summary>
    public BrowserTypeLaunchOptions? BrowserOptions { get; set; }

    /// <summary>
    /// Настройки для Playwright context.
    /// </summary>
    public BrowserNewContextOptions? ContextOptions { get; set; }

    /// <summary>
    /// Настройки для API запросов.
    /// </summary>
    public APIRequestNewContextOptions? ApiOptions { get; set; }
}
