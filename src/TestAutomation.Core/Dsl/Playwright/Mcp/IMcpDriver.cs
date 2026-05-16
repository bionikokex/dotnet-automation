namespace TestAutomation.Core.Dsl.Playwright.Mcp;

/// <summary>
/// Driver-контракт домена MCP.
/// </summary>
public interface IMcpDriver
{
    /// <summary>
    /// Открывает MCP introduction через верхний таб.
    /// </summary>
    Task OpenIntroductionFromTabAsync();
}
