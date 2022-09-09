using ApplicationServices.Members;
using Autofac;

namespace Infrastructure.EndPointConfig.Services;

public static class ConfigAutofac
{
   public static void ConfigureContainer(
       ContainerBuilder container,
       ConfigurationManager configuration)
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
            .WithParameter("SqlServer",configuration
                .GetConnectionString("SqlServer"))
            .AsSelf()
            .InstancePerLifetimeScope();
        
    }
}