using TestAutomation.Core.Infrastructure.Context;
using TestAutomation.Core.Infrastructure.Sessions;

namespace TestAutomation.Core.Abstractions;

/// <summary>
/// Базовый класс для действий, которые выполняются через browser layer.
/// </summary>
public abstract class BrowserAction : IAutomationAction
{
    /// <summary>
    /// Привязывает полиморфное действие к browser session.
    /// </summary>
    public Task ExecuteAsync(AutomationContext context, CancellationToken cancellationToken = default)
        => ExecuteAsync(context.Browser, cancellationToken);

    /// <summary>
    /// Реальная browser-реализация действия.
    /// </summary>
    protected abstract Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken);
}
