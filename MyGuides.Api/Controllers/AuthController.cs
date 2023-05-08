using Microsoft.AspNetCore.Mvc;
using MyGuides.Application.UseCases.Auth; 
using MyGuides.Domain.Entities.Auth.Requests;
using MyGuides.Domain.Entities.Auth.Results; 
using MyGuides.Notifications.Result;

namespace MyGuides.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RequestResult<AuthResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RequestResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateToken([FromBody] CreateTokenRequest request, [FromServices] ICreateTokenUseCase useCase, CancellationToken cancellationToken) 
            => Ok(await useCase.ExecuteAsync(request, cancellationToken));
        
    }
}
