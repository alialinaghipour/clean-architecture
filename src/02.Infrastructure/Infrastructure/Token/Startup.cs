namespace Infrastructure.Token;

static class Startup
{
    internal static IServiceCollection AddTokenService(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSingleton<ITokenService, TokenAppService>();

        return services;
    }
}