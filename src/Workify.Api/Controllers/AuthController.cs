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
        public async Task<IActionResult> Login(LoginContract loginContract)
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
        public async Task<IActionResult> Registration(RegistrationContract registrationContract)
        {
            
            return Ok();
        }

        [Route("log-out")]
        [HttpGet]
        public IActionResult LogOut()
        {
            return Ok();
        }
    }

}
