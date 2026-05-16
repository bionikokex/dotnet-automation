namespace TestAutomation.Core.Dsl.Playwright.Api;

/// <summary>
/// WebApi driver-контракт домена API.
/// </summary>
public interface IApiWebApiDriver
{
    /// <summary>
    /// Проверяет доступность главной страницы через api layer.
    /// </summary>
    Task CheckHomePageAvailabilityAsync();
}
