using Application.Abstractions.Repositories.BrandRepository;
using Core.Persistence.Repositories.Concrete;
using Domain.Entities;
using Persistence.Data.Contexts;

namespace Persistence.Repositories.BrandRepository;

public class BrandReadRepository : EfReadRepositoryBase<Brand, Guid, BaseDbContext>, IBrandReadRepository
{
    public BrandReadRepository(BaseDbContext context) : base(context)
    {
    }
}
