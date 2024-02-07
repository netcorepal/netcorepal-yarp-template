using Prometheus;
using theuc.IngressController.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("/app/config/yarp.json", optional: true);
builder.Services.AddKubernetesReverseProxy(builder.Configuration)
  .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.UseKubernetesReverseProxyCertificateSelector();
}

#region  身份认证
builder.Services.AddAuth(builder.Configuration);
#endregion
builder.Services.AddHealthChecks();
builder.Services.AddYarpProxyStateUI();
var app = builder.Build();

app.UseHealthChecks(path: "/healthz");
app.UseMetricServer(url: "/metrics");
app.UseYarpProxyStateUIStaticFiles();

app.UseRouting();
app.UseYarpProxyStateUI(); // YARP Proxy State UI  http://yourip/_state
app.UseHttpMetrics();
app.MapReverseProxy();

app.Run();


public partial class Program
{
}