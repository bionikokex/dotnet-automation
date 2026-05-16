using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Cli;

/// <summary>
/// DSL домена CLI.
/// </summary>
public sealed class CliDsl : DslBase
{
    private readonly ICliDriver _drivers;

    /// <summary>
    /// Создает CLI DSL и подключает driver collection.
    /// </summary>
    public CliDsl(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(baseDsl, "CLI")
    {
        _drivers = new CliDriverCollection(actor, context, this);
    }

    /// <summary>
    /// Открывает CLI introduction через верхний таб.
    /// </summary>
    public Task OpenIntroductionFromTabAsync()
        => _drivers.OpenIntroductionFromTabAsync();
}
