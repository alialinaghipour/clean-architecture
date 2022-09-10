
namespace Infrastructure.EndPointConfig.Services;

internal static class ConfigAutofac
{
   internal static ConfigureHostBuilder AddConfigAutofac(
      this ConfigureHostBuilder builder,
      IConfiguration configuration)
   {
      builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
      builder.ConfigureContainer<ContainerBuilder>(b =>
         b.RegisterModule(new AutofacBusinessModule(configuration))
      );
      return builder;
   }
}