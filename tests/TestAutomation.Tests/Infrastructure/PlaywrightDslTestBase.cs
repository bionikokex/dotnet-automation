using TestAutomation.Core;
using TestAutomation.Core.Dsl.Playwright;

namespace TestAutomation.Tests.Infrastructure;

/// <summary>
/// NUnit-прослойка: поднимает Playwright runtime в <see cref="SetUp"/> и освобождает в <see cref="TearDown"/>.
/// Тесты получают готовый <see cref="PlaywrightDsl"/> и вызывают доменные методы напрямую:
/// <c>await Dsl.Docs.HomePageEntrySmokeAsync()</c>.
/// Actor находится внутри concrete driver и не виден на уровне тестов.
/// </summary>
public abstract class PlaywrightDslTestBase
{
    private AutomationRuntime? _runtime;
    private PlaywrightDsl? _dsl;

    /// <summary>
    /// Корневой DSL, собранный поверх runtime текущего теста.
    /// Тесты вызывают методы доменов напрямую: <c>Dsl.Docs...</c>, <c>Dsl.Mcp...</c>, <c>Dsl.Cli...</c>, <c>Dsl.Api...</c>.
    /// </summary>
    protected PlaywrightDsl Dsl => _dsl ?? throw new InvalidOperationException("DSL is not initialized.");

    /// <summary>
    /// Настройки runtime для конкретного набора тестов.
    /// </summary>
    protected virtual AutomationOptions CreateOptions() => new()
    {
        BaseUrl = "https://playwright.dev",
        Headless = true
    };

    /// <summary>
    /// Поднимает Playwright runtime перед каждым тестом.
    /// </summary>
    [SetUp]
    public async Task SetUpAsync()
    {
        _runtime = await AutomationRuntime.CreateAsync(CreateOptions());
        _dsl = new PlaywrightDsl(_runtime);
    }

    /// <summary>
    /// Освобождает Playwright runtime после каждого теста.
    /// </summary>
    [TearDown]
    public async Task TearDownAsync()
    {
        if (_runtime is not null)
        {
            await _runtime.DisposeAsync();
            _runtime = null;
            _dsl = null;
        }
    }
}
