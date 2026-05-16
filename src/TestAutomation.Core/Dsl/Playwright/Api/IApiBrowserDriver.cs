namespace TestAutomation.Core.Dsl.Playwright.Api;

/// <summary>
/// Browser driver-контракт домена API.
/// </summary>
public interface IApiBrowserDriver
{
    /// <summary>
    /// Открывает API reference через верхний таб сайта.
    /// </summary>
    Task OpenReferenceFromTabAsync();
}
