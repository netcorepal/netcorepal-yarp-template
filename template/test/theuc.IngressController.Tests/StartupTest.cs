using theuc.IngressController.Tests.Shared;

namespace theuc.IngressController.Tests;

public class StartupTest : IClassFixture<IngressControllerWebApplicationFactory>
{
    private readonly IngressControllerWebApplicationFactory _factory;

    public StartupTest(IngressControllerWebApplicationFactory factory)
    {
        _factory = factory;
    }


    [Fact]
    public async Task Health_API_Test()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/healthz");
        Assert.True(response.IsSuccessStatusCode);

        var str = await response.Content.ReadAsStringAsync();
        Assert.Equal("Healthy", str);
    }

    [Fact]
    public async Task Metrics_API_Test()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/metrics");
        Assert.True(response.IsSuccessStatusCode);

        var str = await response.Content.ReadAsStringAsync();
        Assert.Contains("process_cpu_seconds_total", str);
    }
    
    [Fact]
    public async Task Yarp_State_UI_Page_Test()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/_state");
        Assert.True(response.IsSuccessStatusCode);

        var str = await response.Content.ReadAsStringAsync();
        Assert.Contains("YarpProxyStateLookup", str);
    }
}