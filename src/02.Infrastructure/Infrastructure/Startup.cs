﻿using Infrastructure.Persistence;
using Infrastructure.Sender;
using Infrastructure.Servers;
using Infrastructure.Services;
using Infrastructure.UserIdentity;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        return services
            .AddAspIdentityApi()
            .AddAuthApi(config)
            .AddCorsPolicy()
            .AddMessageSenderService()
            .AddPersistence(config)
            .AddHealth()
            .AddRoutingInfo()
            .AddUserInfoIdentity()
            .AddServicesScoped()
            .AddCustomSwagger();
    }

    public static IApplicationBuilder UseInfrastructure(
        this IApplicationBuilder builder, IConfiguration config)
    {
        return builder
            .UseCorsPolicy()
            .UseHealth()
            .UseCulture()
            .UseEnvelope()
            .UseCustomSwagger()
            .UseHttpsRedirection()
            .UseStaticFiles()
            .UseRouting()
            .UseCorsPolicy()
            .UseRoutingInfo()
            .UseCustomSwagger();
    }

    public static IWebHostBuilder UseInfrastructure(
        this IWebHostBuilder builder,
        IConfiguration config)
    {
        return builder
            .AddServer(config);
    }
}