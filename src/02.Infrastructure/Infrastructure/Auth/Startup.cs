namespace Infrastructure.Auth;

internal static class Startup
{
    internal static IServiceCollection AddAuthApi(
        this IServiceCollection services,
        IConfiguration config)
    {
        var jwtSection = config.GetSection("JwtBearerTokenSettings");
        services.Configure<JwtBearerTokenSettings>(jwtSection);
        var jwtBearerTokenSettings = jwtSection.Get<JwtBearerTokenSettings>();
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
}