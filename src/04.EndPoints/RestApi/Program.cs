
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddInfrastructureApi(configuration);

builder.Host.AddConfigHost(configuration);

var web = builder.WebHost;
web.UseInfrastructureApi(configuration);

var app = builder.Build();
app.UseInfrastructureApi(configuration);
app.Run();