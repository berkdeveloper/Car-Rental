using Application.Features.Brands.Dtos;
using Core.Application.Utilities.Common.Requests;
using Core.Application.Utilities.Common.Responses.Concrete;
using MediatR;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery : IRequest<GetListBaseResponse<GetListBrandListItemDto>>
{
    public PageRequest PageRequest { get; set; }
}
