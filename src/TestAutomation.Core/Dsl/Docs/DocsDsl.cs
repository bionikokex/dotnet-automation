using TestAutomation.Core.Infrastructure.Drivers;
using TestAutomation.Core.Infrastructure.Dsl;

namespace TestAutomation.Core.Dsl.Docs;

/// <summary>
/// DSL домена Docs.
/// </summary>
public sealed class DocsDsl : DslBase
{
    private readonly DriverStack _drivers;

    /// <summary>
    /// Создает Docs DSL с доступом к стеку драйверов.
    /// </summary>
    public DocsDsl(DriverStack drivers, DslBase baseDsl)
        : base(baseDsl, "Документация")
    {
        _drivers = drivers;
    }

    /// <summary>
    /// Проверяет hero и верхнюю навигацию как входной smoke домена Docs.
    /// </summary>
    public async Task HomePageEntrySmokeAsync()
    {
        var ui = _drivers.UI;
        await ui.GotoAsync("/");
        await ui.AssertVisibleAsync("h1:has-text(\"Playwright enables reliable web automation\")");
        await ui.AssertVisibleAsync("nav a:has-text(\"Docs\")");
        await ui.AssertVisibleAsync("nav a:has-text(\"MCP\")");
        await ui.AssertVisibleAsync("nav a:has-text(\"CLI\")");
        await ui.AssertVisibleAsync("nav a:has-text(\"API\")");
    }

    /// <summary>
    /// Открывает intro через hero call-to-action.
    /// </summary>
    public async Task OpenIntroFromHeroAsync()
    {
        var ui = _drivers.UI;
        await ui.GotoAsync("/");
        await ui.ClickAsync("a:has-text(\"Get started\")");
        await ui.AssertUrlContainsAsync("/docs/intro");
    }

    /// <summary>
    /// Открывает intro через верхний таб Docs.
    /// </summary>
    public async Task OpenIntroFromTabAsync()
    {
        var ui = _drivers.UI;
        await ui.GotoAsync("/");
        await ui.ClickAsync("nav a:has-text(\"Docs\")");
        await ui.AssertUrlContainsAsync("/docs/intro");
    }

    /// <summary>
    /// Открывает .NET documentation.
    /// </summary>
    public async Task OpenDotNetDocumentationAsync()
    {
        var ui = _drivers.UI;
        await ui.GotoAsync("/");
        await ui.ClickAsync("main a:has-text(\".NET\")");
        await ui.AssertUrlContainsAsync("/dotnet/docs/intro");
    }
}
