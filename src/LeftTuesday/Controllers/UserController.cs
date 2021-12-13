using LeftTuesday.Models;
using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeftTuesday.Controllers
{
    [Route("User")]
    public class UserController : BaseController
    {
        private readonly UserService _userServcie;

        public UserController(UserService userService)
        {
            _userServcie = userService;
        }

        [HttpGet("get")]
        public IActionResult GetUser([FromQuery] string userName, [FromQuery] string secret)
        {
            return ReturnValueOrError(_userServcie.GetUser(userName, secret));
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] User user)
        {
            return ReturnValueOrError(_userServcie.CreateUser(user));
        }

        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] User user, [FromQuery] string userName, [FromQuery] string secret)
        {
            return ReturnValueOrError(_userServcie.UpdateUser(user, userName, secret));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser([FromQuery] string userName, [FromQuery] string secret)
        {
            return ReturnValueOrError(_userServcie.DeleteUser(userName, secret));
        }
    }
}
