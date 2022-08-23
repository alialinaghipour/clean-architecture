namespace Infrastructure.AspIdentity;

internal static class Startup
{
    internal static IServiceCollection AddAspIdentityApi(
        this IServiceCollection services)
    {
        services.AddScoped<IUserManagementService, UserManagementAppService>();
        services
            .AddScoped<ISignInManagementService, SignInManagementAppService>();

        services
            .AddIdentity<ApplicationUser, ApplicationRole>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 3;
                option.Password.RequireDigit = false;
                option.User.RequireUniqueEmail = true;
                option.Lockout.AllowedForNewUsers = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}