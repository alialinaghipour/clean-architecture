using ApplicationContracts.Contracts;
using ApplicationHandlerContracts.UserLogin;
using ApplicationServiceHandlers.UserLogin;
using ApplicationServices.Members;
using Autofac;
using Identity;
using Infrastructure.EndPointConfig;
using Infrastructure.EndPointConfig.Auth;
using Infrastructure.EndPointConfig.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence.Ef;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
            //services.AddControllersWithViews();
            services.AddInfrastructureApi(Configuration);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Ali>().As<IALi>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(
                typeof(UserLoginAndCreateTokenAppServiceHandler).Assembly,
typeof(UserManagementAppService).Assembly)
                .AssignableTo<IScoped>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(TokenAppService).Assembly)
                .AssignableTo<ISingleton>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //var dd = Configuration.GetConnectionString("SqlServer");
            var dd = Configuration.GetValue<string>("dbConnectionStrings");
            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("dbConnectionStrings", dd)
                .AsSelf()
                .InstancePerLifetimeScope();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            //}

            app.UseInfrastructureApi(Configuration);

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
