using Application.Features.Brands.Commands.Create;
using Domain.Entities;

namespace Application.Abstractions.Services.Brands;

public interface IBrandCommandService
{
    Task<Brand> CreateAsync(CreateBrandCommand request);
}
