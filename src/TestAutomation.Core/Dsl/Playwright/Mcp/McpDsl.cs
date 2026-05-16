using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Mcp;

/// <summary>
/// DSL домена MCP.
/// </summary>
public sealed class McpDsl : DslBase
{
    private readonly IMcpDriver _drivers;

    /// <summary>
    /// Создает MCP DSL и подключает driver collection.
    /// </summary>
    public McpDsl(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(baseDsl, "MCP")
    {
        _drivers = new McpDriverCollection(actor, context, this);
    }

    /// <summary>
    /// Открывает MCP introduction через верхний таб.
    /// </summary>
    public Task OpenIntroductionFromTabAsync()
        => _drivers.OpenIntroductionFromTabAsync();
}
