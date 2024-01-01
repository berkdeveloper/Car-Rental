using Core.Application.Utilities.Common.Responses.ComplexTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers;

public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    public IActionResult ActionResponse<T>(T value) where T : ResponseBase, new()
    {
        value ??= new T();
        return ActionObject(value.StatusCode, value);
    }

    protected IActionResult ActionObject<T>(HttpStatusCode statusCode, T value) where T : ResponseBase, new()
        => statusCode switch
        {
            HttpStatusCode.Created => StatusCode((int)HttpStatusCode.Created),
            HttpStatusCode.NoContent => StatusCode((int)HttpStatusCode.NoContent),
            HttpStatusCode.Accepted => StatusCode((int)HttpStatusCode.Accepted),
            _ => StatusCode((int)value.StatusCode, value),
        };
}
