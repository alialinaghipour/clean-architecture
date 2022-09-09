namespace Infrastructure.EndPointConfig.Cors;

internal static class Startup
{
    private const string CorsPolicy = nameof(CorsPolicy);

    internal static IServiceCollection AddCorsPolicy(
        this IServiceCollection services)
    {
        return services.AddCors(opt =>
            opt.AddPolicy(CorsPolicy, policy =>
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()));
    }

    internal static IApplicationBuilder UseCorsPolicy(
        this IApplicationBuilder app)
    {
        return app.UseCors(CorsPolicy);
    }
}