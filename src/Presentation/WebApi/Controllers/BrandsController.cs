using Application.Features.Brands.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBrandCommand request)
        {
            var response = await Mediator.Send(request);
            return ActionResponse(response);
        }
    }
}
