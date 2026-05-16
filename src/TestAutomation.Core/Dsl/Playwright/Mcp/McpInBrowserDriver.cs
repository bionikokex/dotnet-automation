using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Dsl.Playwright.Actions;

namespace TestAutomation.Core.Dsl.Playwright.Mcp;

/// <summary>
/// Browser driver домена MCP.
/// </summary>
public sealed class McpInBrowserDriver : IMcpDriver
{
    private readonly AutomationActor _actor;

    /// <summary>
    /// Создает browser driver поверх automation actor.
    /// </summary>
    public McpInBrowserDriver(AutomationActor actor)
    {
        _actor = actor;
    }

    /// <inheritdoc />
    public Task OpenIntroductionFromTabAsync()
        => _actor.ExecuteAsync(new CompositeAction(
            new OpenPlaywrightHomePage(),
            new OpenMcpTab(),
            new AssertMcpIntroductionOpened()));
}
