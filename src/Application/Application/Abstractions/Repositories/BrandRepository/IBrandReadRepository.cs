using Core.Persistence.Repositories.Abstractions;
using Core.Persistence.Repositories.Abstractions.Asynchronous;
using Domain.Entities;

namespace Application.Abstractions.Repositories.BrandRepository;

public interface IBrandReadRepository : IReadAsyncRepository<Brand, Guid>, IReadRepository<Brand, Guid>
{
}
