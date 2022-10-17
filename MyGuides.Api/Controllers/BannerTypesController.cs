using Microsoft.AspNetCore.Mvc;
using MyGuides.Application.UseCases;
using MyGuides.Domain.Entities.BannerTypes.Results;
using MyGuides.Notifications.Result;

namespace MyGuides.Api.Controllers
{
    [ApiController]
    [Route("api/banner-types")]
    public class BannerTypesController : ControllerBase
    {
        [HttpGet(Name = "Obter os tipos de Banner")]
        [ProducesResponseType(typeof(RequestResult<BannerTypeResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBannerTypes([FromServices] IGetBannerTypesUseCase useCase, CancellationToken cancellationToken)
        {
            return Ok(await useCase.ExecuteAsync(cancellationToken));
        }
    }
}
