using Application.Abstractions.Repositories.BrandRepository;
using Application.Abstractions.Services.Brands;
using Application.Features.Brands.Queries.GetList;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Persistence.Services.Brands;

public class BrandQueryService : IBrandQueryService
{
    public readonly IBrandReadRepository _brandReadRepository;

    public BrandQueryService(IBrandReadRepository brandReadRepository)
    {
        _brandReadRepository = brandReadRepository;
    }

    public Task<Paginate<Brand>> GetList(GetListBrandQuery request)
    {
        throw new NotImplementedException();
    }
}
