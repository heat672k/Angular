using Microsoft.AspNetCore.Mvc;
using worker_mngmt.DTOs;
using worker_mngmt.Services;

namespace worker_mngmt.Controllers
{
    [ApiController]
    [Route("api/IdentityController")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("[action]")]
        public IActionResult LogIn([FromBody] LogInCreateDto dto)
        {
            var response = _identityService.LogIn(dto);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult RegisterUser([FromBody] RegisterCreateDto dto)
        {
            var response = _identityService.RegisterUser(dto);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult RegisterOrg([FromBody] RegisterCreateDto dto)
        {
            var response = _identityService.RegisterOrg(dto);

            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var response = _identityService.GetById(id);
            return Ok(response);
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            _identityService.DeleteAccount(id);

            return Ok();
        }

    }
}
