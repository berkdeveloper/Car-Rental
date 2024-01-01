using Persistence.Data.Contexts;
using WebApi.Middleware;

namespace WebApi.Extensions;

internal static class ApplicationBuilderExtensions
{
    internal static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
           => builder.UseMiddleware<CustomExceptionHandlerMiddleware>();

    internal static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder builder)
    {
        builder.UseSwagger();

        builder.UseSwaggerUI(swaggerUiOptions => swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Rent A Car API"));

        return builder;
    }

    internal static IApplicationBuilder EnsureDatabaseCreated(this IApplicationBuilder builder)
    {
        using IServiceScope serviceScope = builder.ApplicationServices.CreateScope();

        using BaseDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<BaseDbContext>();

        //dbContext.Database.Migrate();

        return builder;
    }
}
