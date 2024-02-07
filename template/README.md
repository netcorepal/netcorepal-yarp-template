# theuc Ingress Controller

theuc Ingress Controller Project based on YARP.  

More info: <https://github.com/microsoft/reverse-proxy>

## How to Config Ingress

You can use the following annotations to configure the Ingress:

|Annotation|Data Type|
|---|---|
|yarp.ingress.kubernetes.io/authorization-policy|string|
|yarp.ingress.kubernetes.io/rate-limiter-policy|string|
|yarp.ingress.kubernetes.io/output-cache-policy|string|
|yarp.ingress.kubernetes.io/backend-protocol|string|
|yarp.ingress.kubernetes.io/cors-policy|string|
|yarp.ingress.kubernetes.io/health-check|[ActivateHealthCheckConfig](https://microsoft.github.io/reverse-proxy/api/Yarp.ReverseProxy.Configuration.ActiveHealthCheckConfig.html)|
|yarp.ingress.kubernetes.io/http-client|[HttpClientConfig](https://microsoft.github.io/reverse-proxy/api/Yarp.ReverseProxy.Configuration.HttpClientConfig.html)|
|yarp.ingress.kubernetes.io/load-balancing|string|
|yarp.ingress.kubernetes.io/route-metadata|Dictionary<string, string>|
|yarp.ingress.kubernetes.io/session-affinity|[SessionAffinityConfig](https://microsoft.github.io/reverse-proxy/api/Yarp.ReverseProxy.Configuration.SessionAffinityConfig.html)|
|yarp.ingress.kubernetes.io/transforms|List<Dictionary<string, string>>|
|yarp.ingress.kubernetes.io/route-headers|List<[RouteHeader](https://microsoft.github.io/reverse-proxy/api/Yarp.ReverseProxy.Configuration.RouteHeader.html)>|
|yarp.ingress.kubernetes.io/route-order|int|

See: <https://github.com/microsoft/reverse-proxy/tree/main/samples/KubernetesIngress.Sample#annotations>

## Build & Deploy

```shell
docker build -f src/theuc.IngressController/Dockerfile -t theabc:latest .

helm upgrade theabc ./helm-chart --install -f values.yaml
```

## 扩展功能

本项目基于AspNetCore开发，因此具备AspNetCore的所有扩展能力，

See: <https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/>

### 身份认证

### 输出缓存

### 熔断限流

