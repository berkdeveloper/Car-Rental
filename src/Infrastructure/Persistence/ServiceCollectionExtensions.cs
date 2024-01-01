using Application;
using Application.Abstractions.Repositories.BrandRepository;
using Application.Abstractions.Services.Brands;
using Core.Application.Utilities.Rules;
using Core.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.BrandRepository;
using Persistence.Services.Brands;
using System.Reflection;

namespace Persistence;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection AddBrandRepository(this IServiceCollection services)
    {
        services.AddScoped<IBrandReadRepository, BrandReadRepository>();
        services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
        return services;
    }

    private static IServiceCollection AddBrandService(this IServiceCollection services)
    {
        services.AddScoped<IBrandCommandService, BrandCommandService>();
        services.AddScoped<IBrandQueryService, BrandQueryService>();
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBrandRepository()
                .AddBrandService();

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("rentACar"));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }


}
