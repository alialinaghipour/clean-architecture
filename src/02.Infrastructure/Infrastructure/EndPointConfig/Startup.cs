namespace Infrastructure.EndPointConfig;

public static class Startup
{
    public static IServiceCollection AddInfrastructureApi(
        this IServiceCollection services,
        IConfiguration config)
    {
        return services
            .AddAspIdentityApi()
            .AddAuthenticationApi(config)
            .AddCorsPolicy()
            .AddHealth()
            .AddRoutingInfoApi()
            .AddUserInfoIdentity()
            .AddCustomSwagger();
    }

    public static ConfigureHostBuilder AddConfigHost(
        this ConfigureHostBuilder builder,
        IConfiguration config)
    {
        return builder.AddConfigAutofac(config);
    }

    public static IServiceCollection AddInfrastructureWeb(
        this IServiceCollection services)
    {
        return services
            .AddAspIdentityApi()
            .AddRoutingInfoWeb();
    }

    public static IApplicationBuilder UseInfrastructureApi(
        this IApplicationBuilder builder, IConfiguration config)
    {
        return builder
            .UseCorsPolicy()
            .UseCulture()
            .UseEnvelopeApi()
            .UseCustomSwagger()
            .UseHttpsRedirection()
            .UseCorsPolicy()
            .UseRoutingInfoApi()
            .UseCustomSwagger();
    }

    public static IApplicationBuilder UseInfrastructureWeb(
        this IApplicationBuilder builder, IConfiguration config)
    {
        return builder
            .UseHttpsRedirection()
            .UseEnvelopeWeb()
            .UseStaticFiles()
            .UseRoutingInfoWeb();
    }

    public static IWebHostBuilder UseInfrastructureApi(
        this IWebHostBuilder builder,
        IConfiguration config)
    {
        return builder
            .AddServer(config);
    }
}