namespace TestAutomation.Core;

/// <summary>
/// Контракт api layer для HTTP-операций в DSL.
/// </summary>
public interface IApiSession
{
    /// <summary>
    /// Выполняет GET-запрос к относительному route.
    /// </summary>
    Task<ApiResponse> GetAsync(string route, CancellationToken cancellationToken = default);
}
