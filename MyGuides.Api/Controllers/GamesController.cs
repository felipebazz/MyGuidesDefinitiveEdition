using Microsoft.AspNetCore.Mvc;
using MyGuides.Application.UseCases.Games.AddGame;
using MyGuides.Application.UseCases.Games.GetGames;
using MyGuides.Domain.Entities.BannerTypes.Results;
using MyGuides.Domain.Entities.Games.Requests;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Notifications.Result;

namespace MyGuides.Api.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RequestResult<GameResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddGame([FromBody] AddGameRequest request, [FromServices] IAddGameFromSteamStoreUseCase useCase, CancellationToken cancellationToken)
        {
            return Ok(await useCase.ExecuteAsync(request, cancellationToken));
        }

        [HttpGet]
        [ProducesResponseType(typeof(RequestResult<IEnumerable<GameResult>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGames([FromServices] IGetGamesUseCase useCase, CancellationToken cancellationToken)
        {
            return Ok(await useCase.ExecuteAsync(cancellationToken));
        }
    }
}
