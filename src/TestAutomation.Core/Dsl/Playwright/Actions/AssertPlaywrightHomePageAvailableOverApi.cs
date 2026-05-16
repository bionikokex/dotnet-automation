using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Api;

namespace TestAutomation.Core.Dsl.Playwright.Actions;

/// <summary>
/// API action для проверки доступности главной страницы playwright.dev.
/// </summary>
public sealed class AssertPlaywrightHomePageAvailableOverApi : ApiAction
{
    /// <summary>
    /// Выполняет GET-запрос и проверяет, что страница доступна и содержит ожидаемый текст.
    /// </summary>
    protected override async Task ExecuteAsync(IApiSession api, CancellationToken cancellationToken)
    {
        var response = await api.GetAsync(ApiEndpoints.RootPath, cancellationToken);

        if (response.StatusCode is < 200 or >= 300)
        {
            throw new InvalidOperationException($"Home page request failed with status {response.StatusCode}.");
        }

        if (!response.Body.Contains(ApiEndpoints.RootExpectedContent, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Home page response body does not contain the expected hero text.");
        }
    }
}
