using Application.Abstractions.Repositories.BrandRepository;
using Application.Abstractions.Services;
using Application.Features.Brands.Commands.Create;
using Domain.Entities;

namespace Persistence.Services;

public class BrandCommandService : IBrandCommandService
{
    private readonly IBrandWriteRepository _brandWriteRepository;

    public BrandCommandService(IBrandWriteRepository brandWriteRepository)
    {
        _brandWriteRepository = brandWriteRepository;
    }

    public async Task<Brand> CreateAsync(CreateBrandCommand command)
    {
        return new()
        {
            Name = command.Name,
        };
    }
}
