using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure;
using Infrastructure.EndPointConfig;
using Infrastructure.EndPointConfig.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddInfrastructure(configuration);

ConfigAutofac.ConfigureContainer(new ContainerBuilder(),configuration);

var web = builder.WebHost;
web.UseInfrastructure(configuration);

var app = builder.Build();
app.UseInfrastructure(configuration);
app.Run();