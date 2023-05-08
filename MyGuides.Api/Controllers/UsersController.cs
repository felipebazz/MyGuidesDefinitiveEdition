using Microsoft.AspNetCore.Mvc; 
using MyGuides.Application.UseCases.Games.GetGames;
using MyGuides.Application.UseCases.Games.UpdateImages;
using MyGuides.Application.UseCases.Users.AddUser;
using MyGuides.Application.UseCases.Users.GetUsers;
using MyGuides.Domain.Entities.Games.Requests;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Domain.Entities.Users.Requests;
using MyGuides.Domain.Entities.Users.Results;
using MyGuides.Notifications.Result;

namespace MyGuides.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RequestResult<UserResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request, [FromServices] IAddUserUseCase useCase, CancellationToken cancellationToken) 
            => Ok(await useCase.ExecuteAsync(request, cancellationToken));
        

        [HttpGet]
        [ProducesResponseType(typeof(RequestResult<IEnumerable<UserResult>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers([FromBody] GetUserRequest request, [FromServices] IGetUsersUseCase useCase, CancellationToken cancellationToken)
            => Ok(await useCase.ExecuteAsync(request, cancellationToken));

    }
}
