using Application.Abstractions.Services.Brands;
using AutoMapper;
using Core.Application.Utilities.Common.Responses.Concrete;
using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ObjectBaseResponse<CreatedBrandResponse>>
{
    private readonly IBrandCommandService _brandCommandService;
    private readonly IMapper _mapper;

    public CreateBrandCommandHandler(IBrandCommandService brandCommandService, IMapper mapper)
    {
        _brandCommandService = brandCommandService;
        _mapper = mapper;
    }

    public async Task<ObjectBaseResponse<CreatedBrandResponse>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var deneme = await _brandCommandService.CreateAsync(request);

        var response = _mapper.Map<CreatedBrandResponse>(deneme);

        return new ObjectBaseResponse<CreatedBrandResponse>(response, System.Net.HttpStatusCode.Created);
    }
}
