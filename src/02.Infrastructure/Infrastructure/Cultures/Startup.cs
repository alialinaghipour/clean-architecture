namespace Infrastructure.Cultures;

internal static class Startup
{
    internal static IApplicationBuilder UseCulture(
        this IApplicationBuilder app)
    {
        CultureManagement.Culture();
        return app;
    }
}