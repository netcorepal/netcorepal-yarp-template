using Yarp.Kubernetes.Controller.Client;

namespace theuc.IngressController.Extensions;

/// <summary>
/// 
/// </summary>
public class EmptyIngressResourceStatusUpdater : IIngressResourceStatusUpdater
{
    public Task UpdateStatusAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}