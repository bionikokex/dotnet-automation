using TestAutomation.Tests.Infrastructure;

namespace TestAutomation.Tests;

/// <summary>
/// Интеграционные smoke-тесты для playwright.dev, записанные в доменном DSL.
/// Вызов идёт напрямую через <c>Dsl.Docs...</c>, <c>Dsl.Mcp...</c>, <c>Dsl.Cli...</c>, <c>Dsl.Api...</c>.
/// Actor находится внутри concrete driver и не виден на уровне тестов.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.Self)]
public sealed class PlaywrightDslSmokeTests : PlaywrightDslTestBase
{
    /// <summary>
    /// Проверяет Docs-домен: hero-блок и верхнюю навигацию сайта одним DSL-вызовом.
    /// </summary>
    [Test]
    public async Task Docs_HomePageEntrySmoke_CanBeExecutedThroughDomainDsl()
    {
        await Dsl.Docs.HomePageEntrySmokeAsync();
    }

    /// <summary>
    /// Проверяет Docs-домен: переход в intro через верхний таб.
    /// </summary>
    [Test]
    public async Task Docs_OpenIntroFromTab_CanBeExecutedThroughDomainDsl()
    {
        await Dsl.Docs.OpenIntroFromTabAsync();
    }

    /// <summary>
    /// Проверяет Docs-домен: переход в .NET documentation одним DSL-вызовом.
    /// </summary>
    [Test]
    public async Task Docs_OpenDotNetDocumentation_CanBeExecutedThroughDomainDsl()
    {
        await Dsl.Docs.OpenDotNetDocumentationAsync();
    }

    /// <summary>
    /// Проверяет MCP-домен: переход в introduction через верхний таб.
    /// </summary>
    [Test]
    public async Task Mcp_OpenIntroductionFromTab_CanBeExecutedThroughDomainDsl()
    {
        await Dsl.Mcp.OpenIntroductionFromTabAsync();
    }

    /// <summary>
    /// Проверяет CLI-домен: переход в introduction через верхний таб.
    /// </summary>
    [Test]
    public async Task Cli_OpenIntroductionFromTab_CanBeExecutedThroughDomainDsl()
    {
        await Dsl.Cli.OpenIntroductionFromTabAsync();
    }

    /// <summary>
    /// Проверяет API-домен: переход в reference через верхний таб.
    /// </summary>
    [Test]
    public async Task Api_OpenReferenceFromTab_CanBeExecutedThroughDomainDsl()
    {
        await Dsl.Api.OpenReferenceFromTabAsync();
    }

    /// <summary>
    /// Проверяет API-домен: доступность главной страницы через api layer.
    /// </summary>
    [Test]
    public async Task Api_CheckHomePageAvailability_CanRunThroughApiLayer()
    {
        await Dsl.Api.CheckHomePageAvailabilityAsync();
    }
}