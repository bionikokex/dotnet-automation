namespace TestAutomation.Core.Dsl.Playwright.Pages;

/// <summary>
/// Page object для главной страницы playwright.dev.
/// </summary>
public sealed class PlaywrightHomePage
{
    private readonly IBrowserSession _browser;

    // URL fragments
    private const string HomePath = "/";
    private const string DocsIntroFragment = "/docs/intro";
    private const string DotNetDocsIntroFragment = "/dotnet/docs/intro";
    private const string McpIntroductionFragment = "/mcp/introduction";
    private const string CliIntroductionFragment = "/agent-cli/introduction";
    private const string ApiReferenceFragment = "/docs/api/class-playwright";

    // Hero section
    private const string HeroHeading = "h1:has-text(\"Playwright enables reliable web automation\")";

    // Navigation links
    private const string NavDocsLink = "nav a:has-text(\"Docs\")";
    private const string NavMcpLink = "nav a:has-text(\"MCP\")";
    private const string NavCliLink = "nav a:has-text(\"CLI\")";
    private const string NavApiLink = "nav a:has-text(\"API\")";

    // Primary CTA
    private const string GetStartedLink = "a:has-text(\"Get started\")";

    // Documentation links
    private const string DotNetLink = "main a:has-text(\".NET\")";

    /// <summary>
    /// Создает page object поверх browser session.
    /// </summary>
    public PlaywrightHomePage(IBrowserSession browser)
    {
        _browser = browser;
    }

    /// <summary>
    /// Открывает главную страницу сайта.
    /// </summary>
    public Task OpenAsync(CancellationToken cancellationToken = default)
        => _browser.GotoAsync(HomePath, cancellationToken);

    /// <summary>
    /// Проверяет hero-заголовок сайта.
    /// </summary>
    public Task AssertHeroHeadingAsync(CancellationToken cancellationToken = default)
        => _browser.AssertVisibleAsync(HeroHeading, cancellationToken);

    /// <summary>
    /// Проверяет верхнюю навигацию сайта.
    /// </summary>
    public async Task AssertTopNavigationAsync(CancellationToken cancellationToken = default)
    {
        await _browser.AssertVisibleAsync(NavDocsLink, cancellationToken);
        await _browser.AssertVisibleAsync(NavMcpLink, cancellationToken);
        await _browser.AssertVisibleAsync(NavCliLink, cancellationToken);
        await _browser.AssertVisibleAsync(NavApiLink, cancellationToken);
    }

    /// <summary>
    /// Переходит в getting started documentation.
    /// </summary>
    public Task OpenGettingStartedAsync(CancellationToken cancellationToken = default)
        => _browser.ClickAsync(GetStartedLink, cancellationToken);

    /// <summary>
    /// Переходит в Docs через верхний таб.
    /// </summary>
    public Task OpenDocsTabAsync(CancellationToken cancellationToken = default)
        => _browser.ClickAsync(NavDocsLink, cancellationToken);

    /// <summary>
    /// Переходит в MCP через верхний таб.
    /// </summary>
    public Task OpenMcpTabAsync(CancellationToken cancellationToken = default)
        => _browser.ClickAsync(NavMcpLink, cancellationToken);

    /// <summary>
    /// Переходит в CLI через верхний таб.
    /// </summary>
    public Task OpenCliTabAsync(CancellationToken cancellationToken = default)
        => _browser.ClickAsync(NavCliLink, cancellationToken);

    /// <summary>
    /// Переходит в API через верхний таб.
    /// </summary>
    public Task OpenApiTabAsync(CancellationToken cancellationToken = default)
        => _browser.ClickAsync(NavApiLink, cancellationToken);

    /// <summary>
    /// Переходит в .NET documentation.
    /// </summary>
    public Task OpenDotNetDocumentationAsync(CancellationToken cancellationToken = default)
        => _browser.ClickAsync(DotNetLink, cancellationToken);

    /// <summary>
    /// Проверяет открытие getting started documentation.
    /// </summary>
    public Task AssertDocsIntroOpenedAsync(CancellationToken cancellationToken = default)
        => _browser.AssertUrlContainsAsync(DocsIntroFragment, cancellationToken);

    /// <summary>
    /// Проверяет открытие .NET documentation.
    /// </summary>
    public Task AssertDotNetDocsOpenedAsync(CancellationToken cancellationToken = default)
        => _browser.AssertUrlContainsAsync(DotNetDocsIntroFragment, cancellationToken);

    /// <summary>
    /// Проверяет открытие MCP introduction.
    /// </summary>
    public Task AssertMcpIntroductionOpenedAsync(CancellationToken cancellationToken = default)
        => _browser.AssertUrlContainsAsync(McpIntroductionFragment, cancellationToken);

    /// <summary>
    /// Проверяет открытие CLI introduction.
    /// </summary>
    public Task AssertCliIntroductionOpenedAsync(CancellationToken cancellationToken = default)
        => _browser.AssertUrlContainsAsync(CliIntroductionFragment, cancellationToken);

    /// <summary>
    /// Проверяет открытие API reference.
    /// </summary>
    public Task AssertApiReferenceOpenedAsync(CancellationToken cancellationToken = default)
        => _browser.AssertUrlContainsAsync(ApiReferenceFragment, cancellationToken);
}
