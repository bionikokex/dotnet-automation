namespace TestAutomation.Core.Infrastructure.Dsl;

/// <summary>
/// Базовый класс DSL-узла. Хранит родителя и имя для построения полного пути действия.
/// </summary>
public abstract class DslBase
{
    private readonly DslBase? _baseDsl;
    private readonly string _name;

    /// <summary>
    /// Создает DSL-узел с родительским DSL и локальным именем.
    /// </summary>
    protected DslBase(DslBase? baseDsl, string name)
    {
        _baseDsl = baseDsl;
        _name = name;
    }

    /// <summary>
    /// Возвращает полный путь DSL-узла, например <c>Playwright.Документация</c>.
    /// </summary>
    public string GetFullName()
        => _baseDsl is null ? _name : $"{_baseDsl.GetFullName()}.{_name}";
}
