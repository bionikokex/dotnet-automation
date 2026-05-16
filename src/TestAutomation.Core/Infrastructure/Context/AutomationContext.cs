using TestAutomation.Core.Infrastructure.Sessions;

namespace TestAutomation.Core.Infrastructure.Context;

/// <summary>
/// Общий runtime-контекст, содержащий browser и api слои.
/// </summary>
public sealed class AutomationContext
{
    /// <summary>
    /// Создает общий контекст выполнения.
    /// </summary>
    public AutomationContext(IBrowserSession browser, IApiSession api)
    {
        Browser = browser;
        Api = api;
    }

    /// <summary>
    /// Browser layer для UI-операций.
    /// </summary>
    public IBrowserSession Browser { get; }

    /// <summary>
    /// API layer для HTTP-операций.
    /// </summary>
    public IApiSession Api { get; }
}
