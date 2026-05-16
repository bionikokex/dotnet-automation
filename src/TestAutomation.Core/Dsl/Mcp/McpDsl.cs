using TestAutomation.Core.Infrastructure.Drivers;
using TestAutomation.Core.Infrastructure.Dsl;

namespace TestAutomation.Core.Dsl.Mcp;

/// <summary>
/// DSL домена MCP.
/// </summary>
public sealed class McpDsl : DslBase
{
    private readonly DriverStack _drivers;

    /// <summary>
    /// Создает MCP DSL с доступом к стеку драйверов.
    /// </summary>
    public McpDsl(DriverStack drivers, DslBase baseDsl)
        : base(baseDsl, "MCP")
    {
        _drivers = drivers;
    }

    /// <summary>
    /// Открывает MCP introduction через верхний таб.
    /// </summary>
    public async Task OpenIntroductionFromTabAsync()
    {
        var ui = _drivers.UI;
        await ui.GotoAsync("/");
        await ui.ClickAsync("nav a:has-text(\"MCP\")");
        await ui.AssertUrlContainsAsync("/mcp/introduction");
    }
}
