using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;  
using MyGuides.Notifications.Result;

namespace MyGuides.Api.Controllers
{
    [ApiController]
    [Route("api/version")]
    public class VersionController : BaseController
    {
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(RequestResult<string>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok("1.0");
        }
    }
}
