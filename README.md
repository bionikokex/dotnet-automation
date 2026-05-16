# dotnet-automation

Стартовый репозиторий для автоматизации тестирования на **Playwright + C# + DSL**.

## Что внутри

- `browser layer` для UI-действий поверх Playwright `IPage`
- `api layer` для HTTP-действий поверх Playwright `IAPIRequestContext`
- доменный DSL для `https://playwright.dev/`, разбитый по верхним табам `Docs`, `MCP`, `CLI`, `API`
- DSL не хранит селекторы и routes — только намерение
- `NUnit`-прослойка, которая поднимает и закрывает Playwright runtime на каждый тест

## Идея DSL

DSL строится по форме **root DSL → domain DSL → DriverStack → driver → page/api wrappers**:

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
    Abstractions/
    Dsl/
      Api/
      Cli/
      Docs/
      Mcp/
      PlaywrightDsl.cs
    Infrastructure/
      Context/          # AutomationContext, AutomationActor
      Drivers/          # UIDriver, ApiDriver, DriverStack
      Dsl/              # DslBase
      Runtime/          # AutomationRuntime, AutomationOptions
      Sessions/         # IBrowserSession, IApiSession, BrowserLayer, ApiLayer
    Examples/
tests/
  TestAutomation.Tests/
    Infrastructure/
TestAutomation.sln          # Solution файл
```

Для работы со solution используйте:

```bash
# Сборка всего solution
dotnet build TestAutomation.sln

# Запуск тестов через solution
dotnet test TestAutomation.sln
```

## NUnit + Playwright

Тестовый слой переведён на `NUnit`.

`tests/TestAutomation.Tests/Infrastructure/PlaywrightDslTestBase.cs`:

- поднимает `AutomationRuntime` в `[SetUp]`
- отдаёт тестам готовый `PlaywrightDsl`
- закрывает Playwright в `[TearDown]`

Это и есть отдельная прослойка подключения Playwright через NUnit lifecycle.

## Сборка и тестирование

### Локальный запуск

Требуется установленный **.NET SDK 8+**.

```bash
# Восстановление пакетов
dotnet restore

# Сборка
dotnet build --configuration Release

# Установка браузеров Playwright (первый раз)
pwsh tests/TestAutomation.Tests/bin/Release/net8.0/playwright.ps1 install chromium
# Если pwsh не установлен на Windows:
powershell -ExecutionPolicy Bypass -File tests/TestAutomation.Tests/bin/Release/net8.0/playwright.ps1 install chromium

# Опционально: запуск UI-тестов с видимым браузером
TEST_AUTOMATION_HEADLESS=false dotnet test

# Запуск тестов
dotnet test
```

### CI/CD (GitHub Actions)

Проект настроен на автоматическую сборку и тестирование через GitHub Actions.

Workflow запускается при:
- `push` в ветки `main` или `master`
- `pull_request` в ветки `main` или `master`
- Ручном запуске (`workflow_dispatch`)

Структура workflow:
1. Checkout кода
2. Setup .NET 8 SDK
3. Restore dependencies
4. Build (Release конфигурация)
5. Install Playwright browsers
6. Run tests

## Документация

Подробнее архитектура и мотивы описаны в [`docs/architecture.md`](docs/architecture.md).
