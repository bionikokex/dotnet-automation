using TestAutomation.Core.Infrastructure.Context;

namespace TestAutomation.Core.Abstractions;

/// <summary>
/// Композиция нескольких DSL-действий, которую можно выполнить одним вызовом <c>ExecuteAsync</c>.
/// </summary>
public sealed class CompositeAction : IAutomationAction
{
    private readonly IReadOnlyList<IAutomationAction> _actions;

    /// <summary>
    /// Создает последовательность действий, выполняемых по порядку.
    /// </summary>
    public CompositeAction(params IAutomationAction[] actions)
    {
        _actions = actions;
    }

    /// <summary>
    /// Выполняет каждое вложенное действие в одном automation context.
    /// </summary>
    public async Task ExecuteAsync(AutomationContext context, CancellationToken cancellationToken = default)
    {
        foreach (var action in _actions)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await action.ExecuteAsync(context, cancellationToken);
        }
    }
}
