using LeftTuesday.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeftTuesday.Controllers
{
    [Route("Concept")]
    public class ConceptController : Controller
    {
        [HttpGet("getall")]
        public IActionResult GetAllConcepts()
        {
            return Ok(new List<Concept>());
        }
    }
}
