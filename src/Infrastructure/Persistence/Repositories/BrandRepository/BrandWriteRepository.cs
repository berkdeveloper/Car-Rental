using Application.Abstractions.Repositories.BrandRepository;
using Core.Persistence.Repositories.Concrete;
using Domain.Entities;
using Persistence.Data.Contexts;

namespace Persistence.Repositories.BrandRepository;

public class BrandWriteRepository : EfWriteRepositoryBase<Brand, Guid, BaseDbContext>, IBrandWriteRepository
{
    public BrandWriteRepository(BaseDbContext context) : base(context)
    {
    }
}
