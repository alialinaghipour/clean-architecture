var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddInfrastructureWeb();

builder.Host.AddConfigHost(configuration);

var app = builder.Build();

app.UseInfrastructureWeb(configuration);

app.Run();