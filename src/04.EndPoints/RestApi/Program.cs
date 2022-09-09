using ApplicationContracts.Contracts;
using ApplicationServices.Members;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure;
using Infrastructure.Services;
using Persistence.Ef;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddInfrastructure(configuration);

// static void AddServicesAutoFac(ContainerBuilder container,
//     IConfiguration config)
// {
//     container.RegisterAssemblyTypes(typeof(MemberAppService).Assembly)
//         .AssignableTo<IScoped>()
//         .AsImplementedInterfaces()
//         .InstancePerLifetimeScope();
//         
//     container.RegisterAssemblyTypes(typeof(DateTimeAppService).Assembly)
//         .AssignableTo<ISingleton>()
//         .AsImplementedInterfaces()
//         .InstancePerLifetimeScope();
//         
//     container.RegisterType<ApplicationDbContext>()
//         .WithParameter("SqlServer",config.GetConnectionString("SqlServer"))
//         .AsSelf()
//         .InstancePerLifetimeScope();
//         
// }

var web = builder.WebHost;
web.UseInfrastructure(configuration);

var app = builder.Build();
app.UseInfrastructure(configuration);
app.Run();