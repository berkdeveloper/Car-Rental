using Application.Features.Brands.Queries.GetList;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Abstractions.Services.Brands;

public interface IBrandQueryService
{
    Task<Paginate<Brand>> GetList(GetListBrandQuery request);
}
