namespace Infrastructure.EndPointConfig.Envelopes;

internal static class Startup
{
    internal static IApplicationBuilder UseEnvelopeApi(
        this IApplicationBuilder app)
    {
        var environment = app.ApplicationServices
            .GetRequiredService<IWebHostEnvironment>();
        var jsonOptions = app.ApplicationServices
            .GetService<IOptions<JsonOptions>>()?.Value
            .JsonSerializerOptions;

        app.UseExceptionHandler(_ => _.Run(async context =>
        {
            var exception = context.Features
                .Get<IExceptionHandlerPathFeature>()?.Error;
            var errorType = exception?.GetType().Name
                .Replace("Exception", string.Empty);
            var errorDescription = environment.IsProduction()
                ? null
                : exception?.ToString();
            var result = new
            {
                Error = errorType,
                Description = errorDescription
            };

            context.Response.StatusCode =
                StatusCodes.Status500InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(
                JsonSerializer.Serialize(result, jsonOptions));
        }));

        if (environment.IsProduction()) app.UseHsts();

        return app;
    }
    
    internal static IApplicationBuilder UseEnvelopeWeb(
        this IApplicationBuilder app)
    {
        var environment = app.ApplicationServices
            .GetRequiredService<IWebHostEnvironment>();
        var jsonOptions = app.ApplicationServices
            .GetService<IOptions<JsonOptions>>()?.Value
            .JsonSerializerOptions;

        app.UseExceptionHandler(_ => _.Run(async context =>
        {
            var exception = context.Features
                .Get<IExceptionHandlerPathFeature>()?.Error;
            var errorType = exception?.GetType().Name
                .Replace("Exception", string.Empty);
            var errorDescription = environment.IsProduction()
                ? null
                : exception?.ToString();
            var result = new
            {
                Error = errorType,
                Description = errorDescription
            };

            context.Response.StatusCode =
                StatusCodes.Status500InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(
                JsonSerializer.Serialize(result, jsonOptions));
        }));

        if (environment.IsProduction())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        return app;
    }
}