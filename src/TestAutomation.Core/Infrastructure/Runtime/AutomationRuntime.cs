using Microsoft.Playwright;
using TestAutomation.Core.Infrastructure.Context;
using TestAutomation.Core.Infrastructure.Sessions;

namespace TestAutomation.Core.Infrastructure.Runtime;

/// <summary>
/// Runtime для управления Playwright сессиями - browser и api.
/// </summary>
public sealed class AutomationRuntime : IAsyncDisposable
{
    private readonly AutomationOptions _options;
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IAPIRequestContext? _apiContext;
    private IBrowserContext? _browserContext;
    private IPage? _page;

    /// <summary>
    /// Playwright Page для UI операций.
    /// </summary>
    public IPage Page => _page ?? throw new InvalidOperationException("Runtime not initialized. Call InitializeAsync first.");

    /// <summary>
    /// API Request Context для HTTP операций.
    /// </summary>
    public IAPIRequestContext ApiRequestContext => _apiContext ?? throw new InvalidOperationException("Runtime not initialized. Call InitializeAsync first.");

    /// <summary>
    /// Automation actor для выполнения действий.
    /// </summary>
    public AutomationActor Actor => new(CreateContext());

    /// <summary>
    /// Создает runtime с заданными options.
    /// </summary>
    public AutomationRuntime(AutomationOptions? options = null)
    {
        _options = options ?? new AutomationOptions();
    }

    /// <summary>
    /// Инициализирует Playwright, browser и api контексты.
    /// </summary>
    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();

        // Initialize API context
        var apiOptions = _options.ApiOptions ?? new APIRequestNewContextOptions
        {
            BaseURL = _options.BaseUrl
        };
        _apiContext = await _playwright.APIRequest.NewContextAsync(apiOptions);

        // Initialize Browser
        _browser = await _playwright.Chromium.LaunchAsync(_options.BrowserOptions);
        var contextOptions = _options.ContextOptions ?? new BrowserNewContextOptions();
        if (string.IsNullOrEmpty(contextOptions.BaseURL))
        {
            contextOptions.BaseURL = _options.BaseUrl;
        }
        _browserContext = await _browser.NewContextAsync(contextOptions);
        _page = await _browserContext.NewPageAsync();
    }

    /// <summary>
    /// Создает AutomationContext для использования в акторе.
    /// </summary>
    public AutomationContext CreateContext()
    {
        var browserLayer = new BrowserLayer(Page);
        var apiLayer = new ApiLayer(ApiRequestContext);
        return new AutomationContext(browserLayer, apiLayer);
    }

    /// <summary>
    /// Освобождает все ресурсы Playwright.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_page != null)
        {
            await _page.CloseAsync();
            _page = null;
        }

        if (_browserContext != null)
        {
            await _browserContext.CloseAsync();
            _browserContext = null;
        }

        if (_apiContext != null)
        {
            await _apiContext.DisposeAsync();
            _apiContext = null;
        }

        if (_browser != null)
        {
            await _browser.CloseAsync();
            _browser = null;
        }

        _playwright?.Dispose();
        _playwright = null;
    }
}
