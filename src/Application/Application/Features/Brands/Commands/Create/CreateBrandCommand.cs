using Application.Utilities.Common.Responses.Concrete;
using MediatR;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<ObjectBaseResponse<CreatedBrandResponse>>
    {
        public string Name { get; set; }
    }
}
