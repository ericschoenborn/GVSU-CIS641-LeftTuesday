using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        [HttpGet("gettasks/{id}")]
        public IActionResult GetTasks([FromRoute]int id)
        {
            if(id == 1)
            {
                return Ok("Task              Complete\n" +
                    "One                    N" +
                    "Two                    N" +
                    "Three                  N");
            }
            return Ok("Task completed.");
        }

        [HttpGet("user/{id}")]
        public IActionResult SignOff([FromRoute] int id)
        {
            if (id == 1)
            {
                return Unauthorized("You donot have permission to sign off on this task");
            }
            return Ok("Task completed.");
        }
    }
}
