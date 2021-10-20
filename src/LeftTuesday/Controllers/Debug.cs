using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Controllers
{
    [Route("[controller]")]
    public class Debug : Controller
    {
        [HttpGet("ping")]
        public IActionResult Index()
        {
            return Ok("Pong");
        }
    }
}
