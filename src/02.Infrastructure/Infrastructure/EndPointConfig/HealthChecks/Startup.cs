namespace Infrastructure.EndPointConfig.HealthChecks;

internal static class Startup
{
    internal static IServiceCollection AddHealth(
        this IServiceCollection services)
    {
        services.AddRouting();
        services.AddHealthChecks();

        return services;
    }

    internal static IApplicationBuilder UseHealth(
        this IApplicationBuilder app)
    {
        const string url = "/health";

        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapHealthChecks(url));

        return app;
    }
}