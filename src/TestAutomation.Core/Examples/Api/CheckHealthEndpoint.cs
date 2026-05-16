using TestAutomation.Core.Abstractions;
using TestAutomation.Core.Infrastructure.Sessions;

namespace TestAutomation.Core.Examples.Api;

public sealed class CheckHealthEndpoint : ApiAction
{
    protected override async Task ExecuteAsync(IApiSession api, CancellationToken cancellationToken)
    {
        var response = await api.GetAsync("/health", cancellationToken);

        if (response.StatusCode is < 200 or >= 300)
        {
            throw new InvalidOperationException($"Healthcheck failed with status {response.StatusCode}.");
        }
    }
}
