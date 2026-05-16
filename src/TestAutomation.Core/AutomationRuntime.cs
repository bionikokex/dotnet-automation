using Microsoft.Playwright;

namespace TestAutomation.Core;

/// <summary>
/// Поднимает и освобождает Playwright runtime для browser/api слоев.
/// </summary>
public sealed class AutomationRuntime : IAsyncDisposable
{
    private readonly IPlaywright _playwright;
    private readonly IBrowser _browser;
    private readonly IBrowserContext _browserContext;
    private readonly IPage _page;
    private readonly IAPIRequestContext? _dedicatedApiRequestContext;

    private AutomationRuntime(
        IPlaywright playwright,
        IBrowser browser,
        IBrowserContext browserContext,
        IPage page,
        IAPIRequestContext? dedicatedApiRequestContext,
        AutomationActor actor)
    {
        _playwright = playwright;
        _browser = browser;
        _browserContext = browserContext;
        _page = page;
        _dedicatedApiRequestContext = dedicatedApiRequestContext;
        Actor = actor;
    }

    /// <summary>
    /// Актор, через который выполняется DSL.
    /// </summary>
    public AutomationActor Actor { get; }

    /// <summary>
    /// Создает Playwright runtime и собирает общий automation context.
    /// </summary>
    public static async Task<AutomationRuntime> CreateAsync(
        AutomationOptions options,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = options.Headless
        });

        var browserContext = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            BaseURL = options.BaseUrl
        });

        var page = await browserContext.NewPageAsync();
        var dedicatedApiRequestContext = options.ApiBaseUrl is not null &&
                                         !string.Equals(options.ApiBaseUrl, options.BaseUrl, StringComparison.OrdinalIgnoreCase)
            ? await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = options.ApiBaseUrl
            })
            : null;

        var apiRequestContext = dedicatedApiRequestContext ?? browserContext.APIRequest;

        var context = new AutomationContext(
            new BrowserLayer(page),
            new ApiLayer(apiRequestContext));

        return new AutomationRuntime(playwright, browser, browserContext, page, dedicatedApiRequestContext, new AutomationActor(context));
    }

    /// <summary>
    /// Освобождает Playwright ресурсы в корректном порядке.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_dedicatedApiRequestContext is not null)
        {
            await _dedicatedApiRequestContext.DisposeAsync();
        }

        await _page.CloseAsync();
        await _browserContext.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}
