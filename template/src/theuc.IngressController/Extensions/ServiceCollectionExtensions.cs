using Microsoft.Extensions.DependencyInjection.Extensions;
using Yarp.Kubernetes.Controller.Client;

namespace theuc.IngressController.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 修正IngressResourceStatusUpdater出错的问题
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RemoveIngressResourceStatusUpdater(this IServiceCollection services)
    {
        services.Replace(
            ServiceDescriptor.Singleton<IIngressResourceStatusUpdater, EmptyIngressResourceStatusUpdater>());
        return services;
    }
}