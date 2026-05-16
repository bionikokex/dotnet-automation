namespace TestAutomation.Core.Infrastructure.Sessions;

/// <summary>
/// Упрощенная модель HTTP-ответа для DSL и тестового слоя.
/// </summary>
public sealed record ApiResponse(int StatusCode, string Body);
