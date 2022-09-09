using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EndPointConfig.Persistence;

public static class Startup
{
    internal static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration config)
    {
        return services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(config
                .GetConnectionString("SqlServer"));
        });
    }
}