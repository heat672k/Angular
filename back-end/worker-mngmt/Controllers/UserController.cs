using Microsoft.AspNetCore.Mvc;
using worker_mngmt.Services;

namespace worker_mngmt.Controllers
{
    [ApiController]
    [Route("api/UserController")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetApplications([FromRoute] string id)
        {
            var result = _userService.GetApplications(id);

            return Ok(result);
        }
    }
}
