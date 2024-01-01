using Application.Abstractions.Repositories.BrandRepository;
using Core.Application.Common.Exceptions;
using Core.Application.Utilities.Rules;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules : BaseBusinessRules
    {
        private readonly IBrandReadRepository _brandReadRepository;

        public BrandBusinessRules(IBrandReadRepository brandReadRepository)
        {
            _brandReadRepository = brandReadRepository;
        }

        public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            var isExist = await _brandReadRepository.AnyAsync(predicate: b => b.Name.ToLower() == name.ToLower());
            isExist = true;
            if (isExist) throw new ConflictException("This Brand name is already exists.");
        }
    }
}
