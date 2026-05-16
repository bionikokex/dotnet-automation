using Microsoft.Playwright;

namespace TestAutomation.Core.Infrastructure.Drivers;

/// <summary>
/// Унифицированный UI driver — обёртка над Playwright IPage для браузерных действий.
/// </summary>
public sealed class UIDriver
{
    private readonly IPage _page;

    /// <summary>
    /// Создает UI driver поверх Playwright page.
    /// </summary>
    public UIDriver(IPage page)
    {
        _page = page;
    }

    /// <summary>
    /// Открывает относительный адрес внутри базового URL.
    /// </summary>
    public async Task GotoAsync(string relativeUrl, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await _page.GotoAsync(relativeUrl);
    }

    /// <summary>
    /// Кликает по элементу по Playwright selector.
    /// </summary>
    public async Task ClickAsync(string selector, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await _page.Locator(selector).First.ClickAsync();
    }

    /// <summary>
    /// Заполняет поле по selector.
    /// </summary>
    public async Task FillAsync(string selector, string value, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await _page.Locator(selector).First.FillAsync(value);
    }

    /// <summary>
    /// Проверяет видимость элемента по селектору.
    /// </summary>
    public async Task AssertVisibleAsync(string selector, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var isVisible = await _page.Locator(selector).First.IsVisibleAsync();

        if (!isVisible)
        {
            throw new InvalidOperationException($"Element '{selector}' is not visible.");
        }
    }

    /// <summary>
    /// Проверяет текущий URL на ожидаемый фрагмент.
    /// </summary>
    public Task AssertUrlContainsAsync(string expectedValue, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (!_page.Url.Contains(expectedValue, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Current url '{_page.Url}' does not contain '{expectedValue}'.");
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// Возвращает Playwright page для прямого доступа при необходимости.
    /// </summary>
    public IPage Page => _page;
}
