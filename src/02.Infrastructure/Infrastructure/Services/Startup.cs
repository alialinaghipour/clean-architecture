namespace Infrastructure.Services;

internal static class Startup
{
    internal static IServiceCollection AddServicesScoped(
        this IServiceCollection services)
    {
        services.AddScoped<IGenerateCodeService, GenerateCodeAppService>();
        services.AddScoped<IDateTimeService, DateTimeAppService>();

        return services;
    }
}