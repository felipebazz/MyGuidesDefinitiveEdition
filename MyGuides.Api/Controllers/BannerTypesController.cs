using Microsoft.AspNetCore.Mvc;
using MyGuides.Application.UseCases.BannerTypes.GetBannerTypes;
using MyGuides.Domain.Entities.BannerTypes.Results;
using MyGuides.Notifications.Result;

namespace MyGuides.Api.Controllers
{
    [ApiController]
    [Route("api/banner-types")]
    public class BannerTypesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(RequestResult<BannerTypeResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBannerTypes([FromServices] IGetBannerTypesUseCase useCase, CancellationToken cancellationToken)
        {
            return Ok(await useCase.ExecuteAsync(cancellationToken));
        }
    }
}
