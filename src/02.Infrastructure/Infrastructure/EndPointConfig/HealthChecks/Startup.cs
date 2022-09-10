namespace Infrastructure.EndPointConfig.HealthChecks;

internal static class Startup
{
    internal static IServiceCollection AddHealth(
        this IServiceCollection services)
    {
        services.AddHealthChecks();

        return services;
    }
}