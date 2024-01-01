using Application.Features.Brands.Dtos;
using Core.Application.Utilities.Common.Responses.Concrete;
using MediatR;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListBaseResponse<GetListBrandListItemDto>>
{

    public Task<GetListBaseResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
