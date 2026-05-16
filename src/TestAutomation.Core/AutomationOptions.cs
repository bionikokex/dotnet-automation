namespace TestAutomation.Core;

/// <summary>
/// Настройки инициализации Playwright runtime.
/// </summary>
public sealed class AutomationOptions
{
    /// <summary>
    /// Базовый URL для browser layer.
    /// </summary>
    public required string BaseUrl { get; init; }

    /// <summary>
    /// Отдельный базовый URL для api layer.
    /// Если не задан, API использует shared request context из browser context.
    /// </summary>
    public string? ApiBaseUrl { get; init; }

    /// <summary>
    /// Запускать браузер в headless-режиме.
    /// </summary>
    public bool Headless { get; init; } = true;
}
