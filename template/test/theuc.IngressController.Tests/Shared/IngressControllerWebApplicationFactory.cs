using k8s;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace theuc.IngressController.Tests.Shared;

public class IngressControllerWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly TestContainers Containers = new TestContainers();
    private readonly Kubernetes _k8SClient;

    public IngressControllerWebApplicationFactory()
    {
        var configPath = "kube_cfg.cfg";
        File.WriteAllText(configPath, Containers.K3SContainer.GetKubeconfigAsync().Result);
        _k8SClient = new Kubernetes(KubernetesClientConfiguration.BuildConfigFromConfigFile(configPath));
    }


    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //builder.UseSetting("redis:host", _containers.RedisContainer.Hostname);
        //builder.UseSetting("spring:redis:port", _containers.RedisContainer.GetMappedPublicPort(6379).ToString());
        builder.UseEnvironment("Development");
        builder.UseSetting("connectionStrings:redis", Containers.RedisContainer.GetConnectionString());
        builder.ConfigureServices(services => { services.AddSingleton<IKubernetes>(_k8SClient); });
        base.ConfigureWebHost(builder);
    }

    public override async ValueTask DisposeAsync()
    {
        try
        {
            //当前无法优雅退出，所以先释放容器再释放Host
            await Containers.DisposeAsync();
            await base.DisposeAsync();
        }
        catch
        {
            // ignored
        }
    }
}