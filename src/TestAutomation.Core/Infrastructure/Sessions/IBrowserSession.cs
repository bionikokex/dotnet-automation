namespace TestAutomation.Core.Infrastructure.Sessions;

/// <summary>
/// Контракт browser layer, через который DSL взаимодействует с UI.
/// </summary>
public interface IBrowserSession
{
    /// <summary>
    /// Открывает относительный URL внутри базового адреса.
    /// </summary>
    Task GotoAsync(string relativeUrl, CancellationToken cancellationToken = default);

    /// <summary>
    /// Кликает по селектору.
    /// </summary>
    Task ClickAsync(string selector, CancellationToken cancellationToken = default);

    /// <summary>
    /// Заполняет поле по селектору.
    /// </summary>
    Task FillAsync(string selector, string value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверяет, что элемент по селектору видим.
    /// </summary>
    Task AssertVisibleAsync(string selector, CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверяет, что текущий URL содержит ожидаемый фрагмент.
    /// </summary>
    Task AssertUrlContainsAsync(string expectedValue, CancellationToken cancellationToken = default);
}
