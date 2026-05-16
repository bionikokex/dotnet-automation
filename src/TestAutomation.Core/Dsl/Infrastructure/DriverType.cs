namespace TestAutomation.Core.Dsl.Infrastructure;

/// <summary>
/// Тип driver-реализации, через которую будет выполнен DSL-метод.
/// </summary>
public enum DriverType
{
    /// <summary>
    /// Выполнение через browser layer.
    /// </summary>
    InBrowser,

    /// <summary>
    /// Выполнение через api layer.
    /// </summary>
    WebApi
}
