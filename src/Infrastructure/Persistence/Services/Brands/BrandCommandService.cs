using Application.Abstractions.Services.Brands;
using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Rules;
using Domain.Entities;

namespace Persistence.Services.Brands;

public class BrandCommandService : IBrandCommandService
{
    private readonly BrandBusinessRules _brandBusinessRules;

    public BrandCommandService(BrandBusinessRules brandBusinessRules)
    {
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<Brand> CreateAsync(CreateBrandCommand request)
    {
        await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);


        var brand = new Brand();
        brand.SetName(request.Name);
        return brand;
    }
}
