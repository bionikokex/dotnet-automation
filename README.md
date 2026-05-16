# dotnet-automation

Стартовый репозиторий для автоматизации тестирования на **Playwright + C# + DSL**.

## Что внутри

- `browser layer` для UI-действий поверх Playwright `IPage`
- `api layer` для HTTP-действий поверх Playwright `IAPIRequestContext`
- доменный DSL для `https://playwright.dev/`, разбитый по верхним табам `Docs`, `MCP`, `CLI`, `API`
- локаторы и endpoints вынесены в отдельные class-level holders/constants
- DSL не хранит селекторы и routes — только намерение
- `NUnit`-прослойка, которая поднимает и закрывает Playwright runtime на каждый тест
- shared auth-модель через `BrowserContext.APIRequest` для UI + API сценариев

## Идея DSL

DSL строится по форме **root DSL → domain DSL → DriverCollection → driver → page/api wrappers**:

```text
PlaywrightDsl (root)
  ├── DocsDsl
  ├── McpDsl
  ├── CliDsl
  └── ApiDsl
```

Тесты вызывают доменные методы напрямую:

```csharp
await Dsl.Docs.HomePageEntrySmokeAsync();
await Dsl.Mcp.OpenIntroductionFromTabAsync();
await Dsl.Api.CheckHomePageAvailabilityAsync();
```

Actor находится **внутри concrete driver** и не виден на уровне тестов. Локаторы хранятся как class-level constants в page object, endpoints — в отдельном `ApiEndpoints`, не в DSL.

## Структура

```text
src/
  TestAutomation.Core/
    Dsl/
      Infrastructure/
      Playwright/
      Playwright/Api/
      Playwright/Actions/
      Playwright/Pages/
tests/
  TestAutomation.Tests/
    Infrastructure/
docs/
  architecture.md
```

## NUnit + Playwright

Тестовый слой переведён на `NUnit`.

`tests/TestAutomation.Tests/Infrastructure/PlaywrightDslTestBase.cs`:

- поднимает `AutomationRuntime` в `[SetUp]`
- отдаёт тестам готовый `PlaywrightDsl`
- закрывает Playwright в `[TearDown]`

Это и есть отдельная прослойка подключения Playwright через NUnit lifecycle.

## Как запустить локально

Требуется установленный **.NET SDK 8+**.

Основные команды:

```bash
dotnet restore
dotnet test
```

После первого restore нужно установить браузеры Playwright для .NET по инструкции из `Microsoft.Playwright`.

## Документация

Подробнее архитектура и мотивы описаны в [`docs/architecture.md`](docs/architecture.md).
