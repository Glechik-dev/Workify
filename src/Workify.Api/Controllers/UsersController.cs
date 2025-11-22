using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workify.Application.Services;
using Workify.Core.Entities.User;

namespace Workify.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService) 
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ICollection<UserEntity>>> GetAllUser()
        {
            ICollection<UserEntity> users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
