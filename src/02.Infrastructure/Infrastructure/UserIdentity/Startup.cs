namespace Infrastructure.UserIdentity;

internal static class Startup
{
    internal static IServiceCollection AddUserInfoIdentity(
        this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IUserInfoIdentity, HttpContextUserInfoIdentity>();

        return services;
    }
}