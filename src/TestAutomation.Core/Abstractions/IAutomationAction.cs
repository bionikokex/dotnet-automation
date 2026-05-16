using TestAutomation.Core.Infrastructure.Context;

namespace TestAutomation.Core.Abstractions;

/// <summary>
/// Общий контракт для любого DSL-действия в automation runtime.
/// </summary>
public interface IAutomationAction
{
    /// <summary>
    /// Выполняет действие внутри общего automation context.
    /// </summary>
    Task ExecuteAsync(AutomationContext context, CancellationToken cancellationToken = default);
}
