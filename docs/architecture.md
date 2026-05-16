# Architecture

## Цель

Это стартовый шаблон для автоматизации тестирования на **Playwright + C# + DSL**.

Главная идея — описывать действия на разных уровнях, но вызывать их одинаково:

```csharp
await Dsl.Docs.HomePageEntrySmokeAsync();
await Dsl.Api.CheckHomePageAvailabilityAsync();
```

## Форма DSL

Архитектура следует форме **root DSL → domain DSL → DriverCollection → driver → page/api wrappers**:

```text
PlaywrightDsl (root)
  ├── DocsDsl
  ├── McpDsl
  ├── CliDsl
  └── ApiDsl
        │
        ▼
  DriverCollection
        │
        ▼
  [BrowserDriver, ApiDriver]
        │
        ▼
  [BrowserLayer / ApiLayer]
        │
        ▼
  [Page objects / API wrappers]
```

### Уровни

| Уровень | Назначение |
|---------|------------|
| **Root DSL** (`PlaywrightDsl`) | Агрегирует домены поверх готового runtime |
| **Domain DSL** (`DocsDsl`, `McpDsl`, etc.) | Описывает намерение теста методами |
| **DriverCollection** | Выбирает concrete driver по типу |
| **Driver** (`BrowserDriver`, `ApiDriver`) | Содержит actor, управляет lifecycle |
| **Page/API wrappers** | Низкоуровневая механика поверх Playwright |

### Ключевые свойства

- **DSL не хранит селекторы и routes** — локаторы находятся в page object как class-level constants, endpoints вынесены в `ApiEndpoints`
- **Actor находится внутри concrete driver** и не виден на уровне тестов
- **Domain DSL** возвращает async-методы, которые инкапсулируют driver-логику
- **Общая DSL-инфраструктура не лежит внутри домена** — `DslBase`, `DriverCollection`, `DriverType` и `AutomationDriverContext` находятся в `Dsl/Infrastructure`, а `Dsl/Playwright` содержит только playwright.dev-домен.

## Browser layer

`BrowserLayer` — это тонкая обёртка над Playwright `IPage`.

Он даёт понятные методы уровня автоматизации:

- `GotoAsync`
- `FillAsync`
- `ClickAsync`
- `AssertVisibleAsync`
- `AssertUrlContainsAsync`

UI-действия работают только с `IBrowserSession`, а не с сырым `IPage`.

## API layer

`ApiLayer` — обёртка над Playwright `IAPIRequestContext`.

В текущем runtime API-контекст берётся из `BrowserContext.APIRequest`, поэтому UI- и API-слой могут делить одну и ту же авторизацию, cookies и состояние сессии.

## Наследование в DSL

Верхний DSL сделан не плоским helper-классом, а иерархией:

```text
PlaywrightDsl
  └── DocsDsl : DslBase
  └── McpDsl  : DslBase
  └── CliDsl  : DslBase
  └── ApiDsl  : DslBase
```

Каждый домен добавляет только свои доменные сценарии. Это ближе к референсной форме: root DSL агрегирует домены, домены описывают намерение теста, page objects и wrappers выполняют механику.

## Почему такая DSL-форма удобна

1. У тестов один ментальный шаблон: вызвать `Dsl.Docs.Что-тоAsync()`.
2. Browser и API код изолированы друг от друга.
3. Playwright-детали спрятаны внутри layer-обёрток.
4. Локаторы и endpoints хранятся отдельно — DSL содержит только бизнес-логику.
5. При необходимости можно добавить новые слои тем же паттерном, например `MobileAction`.
6. DSL пишется как бизнес-сценарий, а не как последовательность сырых Playwright-команд.

## Структура проекта

```text
src/
  TestAutomation.Core/
    Abstractions/
    Dsl/
      Infrastructure/
        DslBase.cs
        DriverCollection.cs
        DriverType.cs
        AutomationDriverContext.cs
      Playwright/
        Api/
        Actions/
        Pages/
    Examples/
tests/
  TestAutomation.Tests/
    Infrastructure/
docs/
  architecture.md
```

## NUnit-прослойка

Playwright подключается не напрямую из каждого теста, а через `PlaywrightDslTestBase`:

- `[SetUp]` создаёт `AutomationRuntime`, собирает `PlaywrightDsl`
- тест получает готовый `PlaywrightDsl` и вызывает доменные методы напрямую
- `[TearDown]` освобождает browser/page/context/playwright

Actor находится внутри concrete driver и не виден на уровне тестов.

## DSL для playwright.dev

Для живого smoke-покрытия добавлен root `PlaywrightDsl`, внутри которого каждый верхний таб сайта — отдельный DSL-домен.

Желаемая форма записи:

```csharp
await Dsl.Docs.HomePageEntrySmokeAsync();       // hero и верхняя навигация
await Dsl.Docs.OpenIntroFromTabAsync();          // переход в docs/intro
await Dsl.Mcp.OpenIntroductionFromTabAsync();    // переход в MCP introduction
await Dsl.Cli.OpenIntroductionFromTabAsync();    // переход в CLI introduction
await Dsl.Api.OpenReferenceFromTabAsync();        // переход в API reference
await Dsl.Api.CheckHomePageAvailabilityAsync();  // быстрая API-проверка доступности
```

Внутри этого домена:

- `PlaywrightDsl` агрегирует домены верхних табов
- `DocsDsl`, `McpDsl`, `CliDsl`, `ApiDsl` описывают доменные сценарии
- `BrowserLayer` и `ApiLayer` выполняют механику
- Локаторы находятся в `PlaywrightHomePage` как class-level constants, endpoints — в `ApiEndpoints`

## Рекомендуемое развитие

1. Добавить feature-папки (`Features/Auth`, `Features/Catalog`, `Features/Orders`).
2. Вынести конфигурацию в `appsettings.json` и env-переменные.
3. Добавить assertions/helpers для API-ответов и UI-состояния.
4. Подключить CI для `dotnet restore`, `dotnet test` и установки браузеров Playwright.
5. При росте DSL ввести дополнительные Page Objects и компонентный слой поверх `BrowserLayer`.
6. При расширении сайта вынести отдельные домены для docs, search и language navigation.
