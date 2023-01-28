using Infrastructure.Tools;

namespace Infrastructure.EndPointConfig.Services;

public class AutofacBusinessModule : Module
{
    private readonly IConfiguration _configuration;

    public AutofacBusinessModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void Load(ContainerBuilder container)
    {
        var handlerAssembly =
            typeof(UserLoginAndCreateTokenAppServiceHandler).Assembly;
        var serviceAssembly = typeof(MemberAppService).Assembly;
        var frameworkAssembly = typeof(UserManagementAppService).Assembly;
        var repositoryAssembly = typeof(EfMemberRepository).Assembly;
        var infraAssembly = typeof(GenerateCodeAppService).Assembly;
        
        container.RegisterAssemblyTypes(
                handlerAssembly,
                serviceAssembly,
                frameworkAssembly,
                repositoryAssembly,
                infraAssembly)
            .AssignableTo<IScoped>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        container.RegisterAssemblyTypes(
                handlerAssembly,
                serviceAssembly,
                frameworkAssembly,
                repositoryAssembly,
                infraAssembly)
            .AssignableTo<ISingleton>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        var connectionString = _configuration
            .GetValue<string>("dbConnectionStrings")!;
        container.RegisterType<ApplicationDbContext>()
            .WithParameter("dbConnectionStrings", connectionString)
            .AsSelf()
            .InstancePerLifetimeScope();

        base.Load(container);
    }
}