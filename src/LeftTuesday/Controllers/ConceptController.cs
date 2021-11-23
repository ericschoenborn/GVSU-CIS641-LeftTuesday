using LeftTuesday.Models;
using LeftTuesday.Repository;
using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LeftTuesday.Controllers
{
    [Route("Concept")]
    public class ConceptController : BaseController
    {
        //Todo DI
        private ConceptService _conceptService = new ConceptService(new ConceptRepository());

        [HttpGet("all")]
        public IActionResult GetAllConcepts()
        {
            return ReturnValueOrError(_conceptService.GetConcepts());
        }

        [HttpPost("get")]
        public IActionResult CreateConcept([FromQuery] int conceptId)
        {
            return ReturnValueOrError(_conceptService.GetConcept(conceptId));
        }

        [HttpPost("create")]
        public IActionResult CreateConcept([FromBody] Concept concept)
        {
            return ReturnValueOrError(_conceptService.CreateConcept(concept));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteConcept([FromQuery] int conceptId)
        {
            return ReturnValueOrError(_conceptService.DeleteConcept(conceptId));
        }

        [HttpPut("update")]
        public IActionResult UpdateConcept([FromBody] Concept concept)
        {
            return ReturnValueOrError(_conceptService.UpdateConcept(concept));
        }
    }
}
