namespace Infrastructure.EndPointConfig.UserIdentity;

internal static class Startup
{
    internal static IServiceCollection AddUserInfoIdentity(
        this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        return services;
    }
}