using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;

public class BrandCommandProfile : Profile
{
    public BrandCommandProfile()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, BrandDto>().ReverseMap();
    }
}
