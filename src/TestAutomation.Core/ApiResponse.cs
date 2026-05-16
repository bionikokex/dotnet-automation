namespace TestAutomation.Core;

/// <summary>
/// Упрощенная модель HTTP-ответа для DSL и тестового слоя.
/// </summary>
public sealed record ApiResponse(int StatusCode, string Body);
