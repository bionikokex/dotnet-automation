using TestAutomation.Core.Abstractions;

namespace TestAutomation.Core.Infrastructure.Context;

/// <summary>
/// Единая точка выполнения DSL-действий поверх общего automation context.
/// </summary>
public sealed class AutomationActor
{
    private readonly AutomationContext _context;

    /// <summary>
    /// Создает актора для выполнения browser/api действий.
    /// </summary>
    public AutomationActor(AutomationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Выполняет действие или композицию действий.
    /// </summary>
    public Task ExecuteAsync(IAutomationAction action, CancellationToken cancellationToken = default)
        => action.ExecuteAsync(_context, cancellationToken);
}
