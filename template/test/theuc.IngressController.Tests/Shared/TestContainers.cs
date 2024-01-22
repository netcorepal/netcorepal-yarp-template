using Testcontainers.K3s;
using Testcontainers.Redis;

namespace theuc.IngressController.Tests.Shared;

public class TestContainers : IAsyncDisposable
{
    public K3sContainer K3SContainer { get; } =
        new K3sBuilder().Build();

    public TestContainers()
    {
        Task.WhenAll(K3SContainer.StartAsync()).Wait();
    }

    public async ValueTask DisposeAsync()
    {
        await K3SContainer.DisposeAsync();
    }
}