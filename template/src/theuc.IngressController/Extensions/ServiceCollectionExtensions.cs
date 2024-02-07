using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;
using Yarp.Kubernetes.Controller.Client;

namespace theuc.IngressController.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add Authentication
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddDataProtection()
            .PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(configuration.GetConnectionString("redis")!), "DataProtection-Keys");

        var authenticationBuilder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddCookie();
            
        var feishuClientId = configuration["feishu:appId"];
        if (!string.IsNullOrEmpty(feishuClientId))
        {
            authenticationBuilder.AddFeishu(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.ClientId = configuration["feishu:appId"] ?? string.Empty;
                options.ClientSecret = configuration["feishu:appSecret"] ?? string.Empty;
                options.CallbackPath = "/signin-feishu";
            });
        }
        var weixinClientId = configuration["weixin:appId"];
        if (!string.IsNullOrEmpty(weixinClientId))
        {
            authenticationBuilder.AddWeixin(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.ClientId = configuration["weixin:appId"] ?? string.Empty;
                options.ClientSecret = configuration["weixin:appSecret"] ?? string.Empty;
                options.CallbackPath = "/signin-weixin";
            });
        }
        services.AddAuthorization(option =>
        {
            if (!string.IsNullOrEmpty(feishuClientId))
            {

                option.AddPolicy("Feishu", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AuthenticationSchemes.Add("Feishu");
                });
            }
            if (!string.IsNullOrEmpty(weixinClientId))
            {
                option.AddPolicy("Weixin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AuthenticationSchemes.Add("Weixin");
                });
            }
        });
        return services;
    }
}