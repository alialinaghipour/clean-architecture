namespace Infrastructure.Servers;

public static class Startup
{
    public static IWebHostBuilder AddServer(
        this IWebHostBuilder host, IConfiguration config)
    {
        const string urlConfigKey = "url";
        if (config.GetSection(urlConfigKey).Exists())
            host.UseUrls(config.GetValue<string>(urlConfigKey));

        host.UseKestrel();
        host.UseIISIntegration();

        return host;
    }
}