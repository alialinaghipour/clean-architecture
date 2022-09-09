namespace Infrastructure.EndPointConfig.Swagger;

internal static class Startup
{
    private const string ModuleTitle = "Ali";

    internal static IServiceCollection AddCustomSwagger(
        this IServiceCollection services)
    {
        services.AddRouting();

        return services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(_ => _.FullName);

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Example: \"Bearer token\""
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }

    internal static IApplicationBuilder UseCustomSwagger(
        this IApplicationBuilder app)
    {
        var environment = app.ApplicationServices
            .GetRequiredService<IHostEnvironment>();

        if (environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = $"{ModuleTitle} API Documentation";
            });
        }

        return app;
    }

    private static OpenApiInfo CreateApiInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
        {
            Title = $"{ModuleTitle} API {description.ApiVersion}",
            Version = description.ApiVersion.ToString(),
            Description = "API Documentation.",
            Contact = new OpenApiContact
            {
                Name = "",
                Url = new Uri(""),
                Email = "alinaqipourali@gmail.ir"
            },
            TermsOfService = new Uri(""),
            License = new OpenApiLicense
            {
                Name = "Ali",
                Url = new Uri("")
            }
        };

        if (description.IsDeprecated)
            info.Description += " This API version has been deprecated.";

        return info;
    }
}