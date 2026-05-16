using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Actions;
using OpenDotNetDocumentationAction = TestAutomation.Core.Dsl.Playwright.Actions.OpenDotNetDocumentation;

namespace TestAutomation.Core.Dsl.Playwright.Docs;

/// <summary>
/// Browser driver домена Docs.
/// </summary>
public sealed class DocsInBrowserDriver : IDocsDriver
{
    private readonly AutomationActor _actor;

    /// <summary>
    /// Создает browser driver поверх automation actor.
    /// </summary>
    public DocsInBrowserDriver(AutomationActor actor)
    {
        _actor = actor;
    }

    /// <inheritdoc />
    public Task HomePageEntrySmokeAsync()
        => ExecuteAsync(
            new OpenPlaywrightHomePage(),
            new AssertPlaywrightHeroHeading(),
            new AssertPlaywrightTopNavigation());

    /// <inheritdoc />
    public Task OpenIntroFromHeroAsync()
        => ExecuteAsync(
            new OpenPlaywrightHomePage(),
            new OpenGettingStartedDocumentation(),
            new AssertGettingStartedDocumentationOpened());

    /// <inheritdoc />
    public Task OpenIntroFromTabAsync()
        => ExecuteAsync(
            new OpenPlaywrightHomePage(),
            new OpenDocsTab(),
            new AssertGettingStartedDocumentationOpened());

    /// <inheritdoc />
    public Task OpenDotNetDocumentationAsync()
        => ExecuteAsync(
            new OpenPlaywrightHomePage(),
            new OpenDotNetDocumentationAction(),
            new AssertDotNetDocumentationOpened());

    private Task ExecuteAsync(params IAutomationAction[] actions)
        => _actor.ExecuteAsync(new CompositeAction(actions));
}
