namespace Infrastructure.Routing;

public static class Startup
{
    internal static IServiceCollection AddRoutingInfo(
        this IServiceCollection services)
    {
        services.AddRouting();
        services.AddControllers();
        services.AddHttpContextAccessor();

        return services;
    }

    internal static IApplicationBuilder UseRoutingInfo(
        this IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
            endpoints.MapControllers());
        return app;
    }
}