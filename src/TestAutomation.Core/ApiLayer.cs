using Microsoft.Playwright;

namespace TestAutomation.Core;

/// <summary>
/// Тонкая обертка над Playwright <see cref="IAPIRequestContext"/>.
/// </summary>
public sealed class ApiLayer : IApiSession
{
    private readonly IAPIRequestContext _requestContext;

    /// <summary>
    /// Создает API-слой поверх Playwright request context.
    /// </summary>
    public ApiLayer(IAPIRequestContext requestContext)
    {
        _requestContext = requestContext;
    }

    /// <summary>
    /// Выполняет GET-запрос и возвращает упрощенную модель ответа.
    /// </summary>
    public async Task<ApiResponse> GetAsync(string route, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var response = await _requestContext.GetAsync(route, new APIRequestContextOptions
        {
            FailOnStatusCode = false
        });

        return new ApiResponse(response.Status, await response.TextAsync());
    }
}
