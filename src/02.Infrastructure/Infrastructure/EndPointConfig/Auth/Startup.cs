using Microsoft.AspNetCore.Authentication.Cookies;

namespace Infrastructure.EndPointConfig.Auth;

internal static class Startup
{
    internal static IServiceCollection AddAuthenticationApi(
        this IServiceCollection services,
        IConfiguration config)
    {
        var jwtSection = config.GetSection(nameof(TokenSettings));
        services.Configure<TokenSettings>(jwtSection);
        var jwtBearerTokenSettings = jwtSection.Get<TokenSettings>();
        var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme =
                JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.Audience = "Name";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "Name",
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
    
    internal static IServiceCollection AddAuthenticationWeb(
        this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme= CookieAuthenticationDefaults.AuthenticationScheme;

        }).AddCookie(options =>
        {
            options.LoginPath = "/Login";
            options.LogoutPath = "/Logout";
            options.ExpireTimeSpan=TimeSpan.FromMinutes(43200);

        });

        return services;
    }
}