using Microsoft.AspNetCore.Authorization;
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
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginContract loginContract)
        {
            LoginDTO loginDTO = new LoginDTO { Email = loginContract.Email, Password = loginContract.Password  };
            Tokens tokens = await _authService.Login(loginDTO);
            Response.Cookies.Append("access_token", tokens.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddMinutes(60)
            });
            return Ok(tokens);
        }

        [Route("registration/jobseeker")]
        [HttpPost]
        public async Task<IActionResult> RegistrationJobSeeker(RegistrationContract registrationContract)
        {
            try
            {
                RegistrationDTO registrationDTO = new RegistrationDTO { FirstName = registrationContract.FirstName, SecondName = registrationContract.SecondName, Email = registrationContract.Email, PhoneNumber = registrationContract.PhoneNumber, Password = registrationContract.Password, ConfirmPassword = registrationContract.ConfirmPassword };
                Tokens tokens = await _authService.RegistrationJobSeeker(registrationDTO);
                if(tokens != null)
                {
                    Response.Cookies.Append("access_token", tokens.AccessToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        Expires = DateTimeOffset.UtcNow.AddMinutes(60)
                    });
                } else
                {
                    Console.WriteLine("Token not found");
                    throw new Exception("");
                }
                return Ok("User was registrated");
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("registration/employer")]
        [HttpPost]
        public async Task<IActionResult> RegistrationEmployer(RegistrationContract registrationContract) 
        {
            try
            {
                RegistrationDTO registrationDTO = new RegistrationDTO { FirstName = registrationContract.FirstName, SecondName = registrationContract.SecondName, Email = registrationContract.Email, PhoneNumber = registrationContract.PhoneNumber, Password = registrationContract.Password, ConfirmPassword = registrationContract.ConfirmPassword };
                Tokens tokens = await _authService.RegistrationEmployert(registrationDTO);
                if (tokens != null)
                {
                    Response.Cookies.Append("access_token", tokens.AccessToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        Expires = DateTimeOffset.UtcNow.AddMinutes(60)
                    });
                }
                else
                {
                    Console.WriteLine("Token not found");
                    throw new Exception("");
                }
                return Ok("User was registrated");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("log-out")]
        [HttpGet]
        public IActionResult LogOut()
        {
            return Ok();
        }

        [Authorize]
        [Route("check")]
        [HttpGet]
        public IActionResult check()
        {
            return Ok("ok");
        }
    }

}
