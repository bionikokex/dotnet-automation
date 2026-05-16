namespace TestAutomation.Core.Dsl.Playwright.Cli;

/// <summary>
/// Driver-контракт домена CLI.
/// </summary>
public interface ICliDriver
{
    /// <summary>
    /// Открывает CLI introduction через верхний таб.
    /// </summary>
    Task OpenIntroductionFromTabAsync();
}
