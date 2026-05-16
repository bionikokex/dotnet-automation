using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Mcp;

/// <summary>
/// Коллекция drivers домена MCP.
/// </summary>
public sealed class McpDriverCollection : DriverCollection<IMcpDriver>, IMcpDriver
{
    /// <summary>
    /// Создает коллекцию и регистрирует browser driver.
    /// </summary>
    public McpDriverCollection(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(context, baseDsl)
    {
        AddInBrowserDriver(new McpInBrowserDriver(actor));
    }

    /// <inheritdoc />
    public Task OpenIntroductionFromTabAsync()
        => InvokeAsync("Открыть introduction", driver => driver.OpenIntroductionFromTabAsync());
}
