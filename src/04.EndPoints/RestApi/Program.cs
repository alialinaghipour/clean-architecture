using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddInfrastructure(configuration);

var web = builder.WebHost;
web.UseInfrastructure(configuration);

var app = builder.Build();
app.UseInfrastructure(configuration);
app.Run();