using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult ReturnValueOrError<T>((Exception error, T value) result)
        {
            if (result.error != null)
            {
                return BadRequest(result.error.Message);
            }
            return Ok(result.value);
        }
    }
}
