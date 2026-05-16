namespace TestAutomation.Core.Dsl.Playwright.Api;

/// <summary>
/// Константы endpoints для API-домена playwright.dev.
/// </summary>
internal static class ApiEndpoints
{
    /// <summary>
    /// Route главной страницы.
    /// </summary>
    internal const string RootPath = "/";

    /// <summary>
    /// Ожидаемый текст в ответе главной страницы.
    /// </summary>
    internal const string RootExpectedContent = "Fast and reliable end-to-end testing for modern web apps";
}
