using Microsoft.OpenApi.Models;

namespace WebApi.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swaggerGenOptions =>
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Rent A Car API",
                Version = "v1"
            }));

        return services;
    }
}
