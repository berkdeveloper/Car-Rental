using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Dtos;
using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IBrandCommandService
{
    Task<Brand> CreateAsync(CreateBrandCommand command);
}
