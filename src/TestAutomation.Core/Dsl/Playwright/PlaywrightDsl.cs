using TestAutomation.Core.Dsl.Playwright.Api;
using TestAutomation.Core.Dsl.Playwright.Cli;
using TestAutomation.Core.Dsl.Playwright.Docs;
using TestAutomation.Core.Dsl.Infrastructure;
using TestAutomation.Core.Dsl.Playwright.Mcp;

namespace TestAutomation.Core.Dsl.Playwright;

/// <summary>
/// Корневой DSL для playwright.dev, агрегирующий домены верхних табов.
/// </summary>
public sealed class PlaywrightDsl : DslBase
{
    /// <summary>
    /// Создает корневой DSL поверх готового Playwright runtime.
    /// </summary>
    public PlaywrightDsl(AutomationRuntime runtime)
        : this(runtime.Actor, new AutomationDriverContext())
    {
    }

    /// <summary>
    /// Создает корневой DSL и все дочерние домены.
    /// </summary>
    public PlaywrightDsl(AutomationActor actor, AutomationDriverContext context)
        : base(null, "Playwright")
    {
        Docs = new DocsDsl(actor, context, this);
        Mcp = new McpDsl(actor, context, this);
        Cli = new CliDsl(actor, context, this);
        Api = new ApiDsl(actor, context, this);
    }

    /// <summary>
    /// DSL домена Docs.
    /// </summary>
    public DocsDsl Docs { get; }

    /// <summary>
    /// DSL домена MCP.
    /// </summary>
    public McpDsl Mcp { get; }

    /// <summary>
    /// DSL домена CLI.
    /// </summary>
    public CliDsl Cli { get; }

    /// <summary>
    /// DSL домена API.
    /// </summary>
    public ApiDsl Api { get; }
}
