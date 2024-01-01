using Application.Features.Brands.Dtos;
using AutoMapper;
using Core.Application.Utilities.Common.Responses.Concrete;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;

public class BrandQueryProfile : Profile
{
    public BrandQueryProfile()
    {
        CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
        //CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
        CreateMap<Paginate<Brand>, GetListBaseResponse<GetListBrandListItemDto>>().ReverseMap();
    }
}
