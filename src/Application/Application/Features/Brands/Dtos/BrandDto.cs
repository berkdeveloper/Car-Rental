using Application.Common.Core;

namespace Application.Features.Brands.Dtos;

public class BrandDto : AuditBaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
