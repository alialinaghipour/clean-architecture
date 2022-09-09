using Infrastructure.EndPointConfig.AspIdentity;
using Infrastructure.EndPointConfig.Auth;
using Infrastructure.EndPointConfig.Cors;
using Infrastructure.EndPointConfig.Cultures;
using Infrastructure.EndPointConfig.Envelopes;
using Infrastructure.EndPointConfig.HealthChecks;
using Infrastructure.EndPointConfig.Persistence;
using Infrastructure.EndPointConfig.Routing;
using Infrastructure.EndPointConfig.Sender;
using Infrastructure.EndPointConfig.Servers;
using Infrastructure.EndPointConfig.Services;
using Infrastructure.EndPointConfig.Swagger;
using Infrastructure.EndPointConfig.UserIdentity;

namespace Infrastructure.EndPointConfig;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        return services
            .AddPersistence(config)
            .AddAspIdentityApi()
            .AddAuthenticationApi(config)
            .AddCorsPolicy()
            .AddMessageSenderService()
            .AddHealth()
            .AddRoutingInfo()
            .AddUserInfoIdentity()
            .AddServicesScoped(config)
            .AddCustomSwagger();
    }

    public static IApplicationBuilder UseInfrastructure(
        this IApplicationBuilder builder, IConfiguration config)
    {
        return builder
            .UseCorsPolicy()
           // .UseHealth()
            .UseCulture()
            .UseEnvelope()
            .UseCustomSwagger()
            .UseHttpsRedirection()
            .UseStaticFiles()
            .UseRouting()
            .UseCorsPolicy()
            .UseRoutingInfo()
            .UseCustomSwagger();
    }

    public static IWebHostBuilder UseInfrastructure(
        this IWebHostBuilder builder,
        IConfiguration config)
    {
        return builder
            .AddServer(config);
    }
}