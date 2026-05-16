using TestAutomation.Core.Dsl;
using TestAutomation.Core.Infrastructure.Context;
using TestAutomation.Core.Infrastructure.Runtime;

namespace TestAutomation.Tests.Infrastructure;

/// <summary>
/// NUnit-прослойка: поднимает Playwright runtime в <see cref="SetUp"/> и освобождает в <see cref="TearDown"/>.
/// Тесты получают готовый <see cref="PlaywrightDsl"/> и вызывают доменные методы напрямую:
/// <c>await Dsl.Docs.HomePageEntrySmokeAsync()</c>.
/// Actor находится внутри concrete driver и не виден на уровне тестов.
/// </summary>
public abstract class PlaywrightDslTestBase
{
    private const string HeadlessEnvironmentVariable = "TEST_AUTOMATION_HEADLESS";

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
    protected virtual AutomationOptions CreateOptions()
    {
        var options = new AutomationOptions
        {
            BaseUrl = "https://playwright.dev"
        };

        if (ResolveHeadlessMode())
        {
            options.BrowserOptions = new() { Headless = true };
        }

        return options;
    }

    private static bool ResolveHeadlessMode()
    {
        var configuredValue = Environment.GetEnvironmentVariable(HeadlessEnvironmentVariable);

        return bool.TryParse(configuredValue, out var headless)
            ? headless
            : true;
    }

    /// <summary>
    /// Поднимает Playwright runtime перед каждым тестом.
    /// </summary>
    [SetUp]
    public async Task SetUpAsync()
    {
        _runtime = new AutomationRuntime(CreateOptions());
        await _runtime.InitializeAsync();
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
