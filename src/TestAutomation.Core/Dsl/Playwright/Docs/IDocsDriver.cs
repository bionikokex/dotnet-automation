namespace TestAutomation.Core.Dsl.Playwright.Docs;

/// <summary>
/// Driver-контракт домена Docs.
/// </summary>
public interface IDocsDriver
{
    /// <summary>
    /// Проверяет входную страницу документации.
    /// </summary>
    Task HomePageEntrySmokeAsync();

    /// <summary>
    /// Открывает intro через hero call-to-action.
    /// </summary>
    Task OpenIntroFromHeroAsync();

    /// <summary>
    /// Открывает intro через таб Docs.
    /// </summary>
    Task OpenIntroFromTabAsync();

    /// <summary>
    /// Открывает .NET документацию.
    /// </summary>
    Task OpenDotNetDocumentationAsync();
}
