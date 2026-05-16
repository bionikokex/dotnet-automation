using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Docs;

/// <summary>
/// Коллекция drivers домена Docs.
/// </summary>
public sealed class DocsDriverCollection : DriverCollection<IDocsDriver>, IDocsDriver
{
    /// <summary>
    /// Создает коллекцию и регистрирует browser driver.
    /// </summary>
    public DocsDriverCollection(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(context, baseDsl)
    {
        AddInBrowserDriver(new DocsInBrowserDriver(actor));
    }

    /// <inheritdoc />
    public Task HomePageEntrySmokeAsync()
        => InvokeAsync("Проверить входную страницу", driver => driver.HomePageEntrySmokeAsync());

    /// <inheritdoc />
    public Task OpenIntroFromHeroAsync()
        => InvokeAsync("Открыть intro через hero", driver => driver.OpenIntroFromHeroAsync());

    /// <inheritdoc />
    public Task OpenIntroFromTabAsync()
        => InvokeAsync("Открыть intro через таб", driver => driver.OpenIntroFromTabAsync());

    /// <inheritdoc />
    public Task OpenDotNetDocumentationAsync()
        => InvokeAsync("Открыть .NET documentation", driver => driver.OpenDotNetDocumentationAsync());
}
