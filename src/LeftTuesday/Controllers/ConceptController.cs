using LeftTuesday.Models;
using LeftTuesday.Repository;
using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeftTuesday.Controllers
{
    [Route("Concept")]
    public class ConceptController : Controller
    {
        //Todo DI
        private ConceptService _conceptService = new ConceptService(new ConceptRepository());

        public IActionResult GetAllConcepts()
        {
            //Todo User validation

            return Ok(new List<Concept>());
        }

        [HttpPost("create")]
        public IActionResult CreateConcept([FromBody] Concept concept)
        {
            //Todo User validation
            var (error, value) = _conceptService.CreateConcept(concept);

            if (error != null)
            {
                return BadRequest(error.Message);
            }
            return Ok(value);
        }

        [HttpPost("get")]
        public IActionResult CreateConcept([FromQuery] int conceptId)
        {
            //Todo User validation
            var (error, value) = _conceptService.GetConcept(conceptId);

            if (error != null)
            {
                return BadRequest(error.Message);
            }
            return Ok(value);
        }
    }
}
