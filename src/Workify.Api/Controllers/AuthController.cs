using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Workify.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Route("login")]
        [HttpGet]
        public IActionResult login() 
        {
            return Ok();
        }

        [Route("sign-up")]
        [HttpGet]
        public IActionResult signUp()
        {
            return Ok();
        }

        [Route("log-out")]
        [HttpGet]
        public IActionResult logOut()
        {
            return Ok();
        }
    }
}
