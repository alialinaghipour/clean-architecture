using Infrastructure.Tools;

namespace Infrastructure.EndPointConfig.Services;

internal static class Startup
{
    internal static IServiceCollection AddServicesScoped(
        this IServiceCollection services,
        IConfiguration config)
    {
        services
            .AddScoped<IGenerateCodeService, GenerateCodeAppService>();
        services
            .AddScoped<IDateTimeService, DateTimeAppService>();
        services
            .AddScoped<IUserManagementService, UserManagementAppService>();
        services
            .AddScoped<ISignInManagementService, SignInManagementAppService>();
        services
            .AddScoped<TokenSettings>();
        services
            .AddScoped<ITokenService, TokenAppService>();
        services
            .AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(config
                .GetConnectionString("SqlServer"));
        });
        services
            .AddScoped<IUserInfoIdentity, HttpContextUserInfoIdentity>();
        services
            .AddScoped<IGenerateCodeService,GenerateCodeAppService>();
        services
            .AddScoped<IUnitOfWork, EfUnitOfWork>();
        services
            .AddScoped<ICreateMemberAndUserHandler, CreateMemberAndUserServiceHandler>();
        services
            .AddScoped<IUserLoginAndCreateTokenServiceHandler, UserLoginAndCreateTokenAppServiceHandler>();
        services
            .AddScoped<IUnitOfWork, EfUnitOfWork>();
        services
            .AddScoped<IMemberService, MemberAppService>();
        services
            .AddScoped<IMemberRepository, EfMemberRepository>();


        return services;
    }
    
    internal static void AddServicesAutoFac(
        this ContainerBuilder container,
        IConfiguration config)
    {
        container.RegisterAssemblyTypes(typeof(MemberAppService).Assembly)
            .AssignableTo<IScoped>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        container.RegisterAssemblyTypes(typeof(DateTimeAppService).Assembly)
            .AssignableTo<ISingleton>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
        container.RegisterType<ApplicationDbContext>()
            .WithParameter("SqlServer",config.GetConnectionString("SqlServer"))
            .AsSelf()
            .InstancePerLifetimeScope();
        
    }

    internal static ConfigureHostBuilder A(this ConfigureHostBuilder builder)
    {
        builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        return builder;
        // builder.ConfigureContainer()
    }
}