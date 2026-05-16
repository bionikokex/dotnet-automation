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
    private readonly DriverStack _drivers;

    /// <summary>
    /// Создает корневой DSL поверх готового Playwright runtime.
    /// </summary>
    public PlaywrightDsl(AutomationRuntime runtime)
        : this(runtime.Actor, runtime)
    {
    }

    /// <summary>
    /// Создает корневой DSL и все дочерние домены.
    /// </summary>
    public PlaywrightDsl(AutomationActor actor, AutomationRuntime runtime)
        : base(null, "Playwright")
    {
        _drivers = new DriverStack(
            new UIDriver(runtime.Page),
            new ApiDriver(runtime.ApiRequestContext));

        Docs = new DocsDsl(_drivers, this);
        Mcp = new McpDsl(_drivers, this);
        Cli = new CliDsl(_drivers, this);
        Api = new ApiDsl(_drivers, this);
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

    /// <summary>
    /// Стек драйверов (UI + Api).
    /// </summary>
    internal DriverStack Drivers => _drivers;
}
