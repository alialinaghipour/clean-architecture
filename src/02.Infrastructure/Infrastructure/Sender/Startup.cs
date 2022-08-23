using ApplicationContracts.Contracts.Sender;

namespace Infrastructure.Sender;

public static class Startup
{
    internal static IServiceCollection AddMessageSenderService(
        this IServiceCollection services)
    {
        services.AddScoped<IMessageSenderService, MessageSenderAppService>();

        return services;
    }
}