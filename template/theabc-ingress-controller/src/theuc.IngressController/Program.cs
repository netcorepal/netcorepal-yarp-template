using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("/app/config/yarp.json", optional: true);
builder.Services.AddKubernetesReverseProxy(builder.Configuration);
builder.WebHost.UseKubernetesReverseProxyCertificateSelector();

builder.Services.AddHealthChecks();
builder.Services.AddYarpProxyStateUI();
var app = builder.Build();
app.UseRouting();
app.UseHealthChecks(path: "/healthz");
app.UseMetricServer(url: "/metrics");
app.UseYarpProxyStateUI(); // YARP Proxy State UI  http://yourip/_state
app.MapReverseProxy();

app.Run();
