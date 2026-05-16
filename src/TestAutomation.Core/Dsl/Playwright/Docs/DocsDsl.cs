using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Docs;

/// <summary>
/// DSL домена Docs.
/// </summary>
public sealed class DocsDsl : DslBase
{
    private readonly IDocsDriver _drivers;

    /// <summary>
    /// Создает Docs DSL и подключает driver collection.
    /// </summary>
    public DocsDsl(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(baseDsl, "Документация")
    {
        _drivers = new DocsDriverCollection(actor, context, this);
    }

    /// <summary>
    /// Проверяет hero и верхнюю навигацию как входной smoke домена Docs.
    /// </summary>
    public Task HomePageEntrySmokeAsync()
        => _drivers.HomePageEntrySmokeAsync();

    /// <summary>
    /// Открывает intro через hero call-to-action.
    /// </summary>
    public Task OpenIntroFromHeroAsync()
        => _drivers.OpenIntroFromHeroAsync();

    /// <summary>
    /// Открывает intro через верхний таб Docs.
    /// </summary>
    public Task OpenIntroFromTabAsync()
        => _drivers.OpenIntroFromTabAsync();

    /// <summary>
    /// Открывает .NET documentation.
    /// </summary>
    public Task OpenDotNetDocumentationAsync()
        => _drivers.OpenDotNetDocumentationAsync();
}
