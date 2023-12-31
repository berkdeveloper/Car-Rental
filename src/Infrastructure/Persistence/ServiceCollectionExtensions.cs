using Application.Abstractions.Repositories.BrandRepository;
using Application.Abstractions.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.BrandRepository;
using Persistence.Services;

namespace Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("rentACar"));
        services.AddScoped<IBrandReadRepository, BrandReadRepository>();
        services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
        services.AddScoped<IBrandCommandService, BrandCommandService>();

        return services;
    }
}
