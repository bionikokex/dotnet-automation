using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Infrastructure.Context;
using TestAutomation.Core.Infrastructure.Sessions;

namespace TestAutomation.Tests;

/// <summary>
/// Unit-тесты на полиморфную маршрутизацию действий через <see cref="AutomationActor"/>.
/// </summary>
[TestFixture]
public sealed class AutomationActorTests
{
    /// <summary>
    /// Проверяет, что browser action уходит в browser layer через единый entry point.
    /// </summary>
    [Test]
    public async Task ExecuteAsync_InvokesBrowserActionThroughSingleEntryPoint()
    {
        var browser = new FakeBrowserSession();
        var api = new FakeApiSession();
        var actor = new AutomationActor(new AutomationContext(browser, api));

        await actor.ExecuteAsync(new BrowserProbeAction());

        Assert.That(browser.WasCalled, Is.True);
        Assert.That(api.WasCalled, Is.False);
    }

    /// <summary>
    /// Проверяет, что api action уходит в api layer через единый entry point.
    /// </summary>
    [Test]
    public async Task ExecuteAsync_InvokesApiActionThroughSingleEntryPoint()
    {
        var browser = new FakeBrowserSession();
        var api = new FakeApiSession();
        var actor = new AutomationActor(new AutomationContext(browser, api));

        await actor.ExecuteAsync(new ApiProbeAction());

        Assert.That(api.WasCalled, Is.True);
        Assert.That(browser.WasCalled, Is.False);
    }

    /// <summary>
    /// Browser-проба для unit-теста маршрутизации.
    /// </summary>
    private sealed class BrowserProbeAction : BrowserAction
    {
        protected override Task ExecuteAsync(IBrowserSession browser, CancellationToken cancellationToken)
            => browser.GotoAsync("/", cancellationToken);
    }

    /// <summary>
    /// API-проба для unit-теста маршрутизации.
    /// </summary>
    private sealed class ApiProbeAction : ApiAction
    {
        protected override async Task ExecuteAsync(IApiSession api, CancellationToken cancellationToken)
            => _ = await api.GetAsync("/health", cancellationToken);
    }

    /// <summary>
    /// Фейковая browser session без реального Playwright runtime.
    /// </summary>
    private sealed class FakeBrowserSession : IBrowserSession
    {
        public bool WasCalled { get; private set; }

        public Task GotoAsync(string relativeUrl, CancellationToken cancellationToken = default)
        {
            WasCalled = true;
            return Task.CompletedTask;
        }

        public Task ClickAsync(string selector, CancellationToken cancellationToken = default)
        {
            WasCalled = true;
            return Task.CompletedTask;
        }

        public Task FillAsync(string selector, string value, CancellationToken cancellationToken = default)
        {
            WasCalled = true;
            return Task.CompletedTask;
        }

        public Task AssertVisibleAsync(string selector, CancellationToken cancellationToken = default)
        {
            WasCalled = true;
            return Task.CompletedTask;
        }

        public Task AssertUrlContainsAsync(string expectedValue, CancellationToken cancellationToken = default)
        {
            WasCalled = true;
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Фейковая API session без реального HTTP.
    /// </summary>
    private sealed class FakeApiSession : IApiSession
    {
        public bool WasCalled { get; private set; }

        public Task<ApiResponse> GetAsync(string route, CancellationToken cancellationToken = default)
        {
            WasCalled = true;
            return Task.FromResult(new ApiResponse(200, "ok"));
        }
    }
}
