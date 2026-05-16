using TestAutomation.Core.Infrastructure.Drivers;
using TestAutomation.Core.Infrastructure.Dsl;

namespace TestAutomation.Core.Dsl.Cli;

/// <summary>
/// DSL домена CLI.
/// </summary>
public sealed class CliDsl : DslBase
{
    private readonly DriverStack _drivers;

    /// <summary>
    /// Создает CLI DSL с доступом к стеку драйверов.
    /// </summary>
    public CliDsl(DriverStack drivers, DslBase baseDsl)
        : base(baseDsl, "CLI")
    {
        _drivers = drivers;
    }

    /// <summary>
    /// Открывает CLI introduction через верхний таб.
    /// </summary>
    public async Task OpenIntroductionFromTabAsync()
    {
        var ui = _drivers.UI;
        await ui.GotoAsync("/");
        await ui.ClickAsync("nav a:has-text(\"CLI\")");
        await ui.AssertUrlContainsAsync("/agent-cli/introduction");
    }
}
