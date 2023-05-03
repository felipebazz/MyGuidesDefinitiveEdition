using Microsoft.AspNetCore.Mvc;
using MyGuides.Application.UseCases.Achievements.GetAchievements;
using MyGuides.Domain.Entities.Achievements.Queries.GetAchievements;
using MyGuides.Domain.Entities.Achievements.Results;
using MyGuides.Notifications.Result;

namespace MyGuides.Api.Controllers
{
    [ApiController]
    [Route("api/achievements")]
    public class AchievementsController : ControllerBase
    {
        [HttpGet("game/{id:guid}")]
        [ProducesResponseType(typeof(RequestResult<IEnumerable<AchievementResult>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByGameId(Guid id, [FromServices] IGetAchievementsUseCase useCase, CancellationToken cancellationToken)
        {
            return Ok(await useCase.ExecuteAsync(new GetAchievementsQuery(id), cancellationToken));
        }
    }
}
