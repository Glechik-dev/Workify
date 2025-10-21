using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workify.Api.Contracts;
using Workify.Application.DTO;
using Workify.Application.Services;

namespace Workify.Api.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _tokenService;

        public AuthController(JwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }


        [Route("login")]
        [HttpGet]
        public async Task<IActionResult> login(LoginContract loginContract)
        {
            Tokens tokens = _tokenService.GetTokens(new UserDTO()
            {
                Id = "1",
                Name = "Egor",
                Email = "exapmle@gmail.com"
            } );
            return Ok(tokens);
        }

        [Route("sign-up")]
        [HttpGet]
        public IActionResult registration()
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
