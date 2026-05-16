using Microsoft.Playwright;
using TestAutomation.Core.Infrastructure.Sessions;

namespace TestAutomation.Core.Infrastructure.Drivers;

/// <summary>
/// Унифицированный API driver — обёртка над Playwright IAPIRequestContext для HTTP-действий.
/// </summary>
public sealed class ApiDriver
{
    private readonly IAPIRequestContext _requestContext;

    /// <summary>
    /// Создает API driver поверх Playwright request context.
    /// </summary>
    public ApiDriver(IAPIRequestContext requestContext)
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

    /// <summary>
    /// Возвращает Playwright request context для прямого доступа при необходимости.
    /// </summary>
    public IAPIRequestContext RequestContext => _requestContext;
}
