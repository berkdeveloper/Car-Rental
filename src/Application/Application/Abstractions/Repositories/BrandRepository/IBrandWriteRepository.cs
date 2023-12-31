using Core.Persistence.Repositories.Abstractions.Asynchronous;
using Core.Persistence.Repositories.Abstractions;
using Domain.Entities;

namespace Application.Abstractions.Repositories.BrandRepository
{
    public interface IBrandWriteRepository : IWriteAsyncRepository<Brand, Guid>, IWriteRepository<Brand, Guid>
    {
    }
}
