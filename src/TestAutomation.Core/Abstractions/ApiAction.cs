namespace TestAutomation.Core.Abstractions;

/// <summary>
/// Базовый класс для действий, которые выполняются через api layer.
/// </summary>
public abstract class ApiAction : IAutomationAction
{
    /// <summary>
    /// Привязывает полиморфное действие к api session.
    /// </summary>
    public Task ExecuteAsync(AutomationContext context, CancellationToken cancellationToken = default)
        => ExecuteAsync(context.Api, cancellationToken);

    /// <summary>
    /// Реальная api-реализация действия.
    /// </summary>
    protected abstract Task ExecuteAsync(IApiSession api, CancellationToken cancellationToken);
}
