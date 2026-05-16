using TestAutomation.Core.Dsl.Infrastructure;

namespace TestAutomation.Core.Dsl.Playwright.Cli;

/// <summary>
/// Коллекция drivers домена CLI.
/// </summary>
public sealed class CliDriverCollection : DriverCollection<ICliDriver>, ICliDriver
{
    /// <summary>
    /// Создает коллекцию и регистрирует browser driver.
    /// </summary>
    public CliDriverCollection(AutomationActor actor, AutomationDriverContext context, DslBase baseDsl)
        : base(context, baseDsl)
    {
        AddInBrowserDriver(new CliInBrowserDriver(actor));
    }

    /// <inheritdoc />
    public Task OpenIntroductionFromTabAsync()
        => InvokeAsync("Открыть introduction", driver => driver.OpenIntroductionFromTabAsync());
}
