using Microsoft.AspNetCore.Mvc;
using MyGuides.Application.UseCases.Sections.GetSections;
using MyGuides.Domain.Entities.Sections.Queries;
using MyGuides.Domain.Entities.Sections.Results;
using MyGuides.Notifications.Result;

namespace MyGuides.Api.Controllers
{
    [ApiController]
    [Route("api/sections")]
    public class SectionsController : BaseController
    {
        [HttpGet("{gameId:guid}")]
        [ProducesResponseType(typeof(RequestResult<List<SectionResult>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByGameId(Guid id, [FromServices] IGetSectionsUseCase useCase, CancellationToken cancellationToken)
        {
            return Ok(await useCase.ExecuteAsync(new GetSectionsQuery(id), cancellationToken));
        }
    }
}
