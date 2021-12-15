using LeftTuesday.Models;
using LeftTuesday.Repository;
using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeftTuesday.Controllers
{
    [Route("Concept")]
    public class ConceptController : BaseController
    {
        private readonly ConceptService _conceptService;

        public ConceptController(ConceptService conceptService)
        {
            _conceptService = conceptService;
        }

        [HttpGet("all")]
        public IActionResult GetAllConcepts()
        {
            return ReturnValueOrError(_conceptService.GetConcepts());
        }

        [HttpGet("get/{ownerId}")]
        public IActionResult GetConcept([FromQuery] int conceptId, long ownerId)
        {
            return ReturnValueOrError(_conceptService.GetConcept(conceptId, ownerId));
        }

        [HttpGet("getowners")]
        public IActionResult GetAllOwners()
        {
            return ReturnValueOrError(_conceptService.GetAllConceptOwners());
        }

        [HttpPost("create/{ownerId}")]
        public IActionResult CreateConcept([FromBody] Concept concept, long ownerId)
        {
            return ReturnValueOrError(_conceptService.CreateConcept(concept, ownerId));
        }

        [HttpPut("update/{ownerId}")]
        public IActionResult UpdateConcept([FromBody] Concept concept, long ownerId)
        {
            return ReturnValueOrError(_conceptService.UpdateConcept(concept,ownerId));
        }

        [HttpDelete("delete/{ownerId}")]
        public IActionResult DeleteConcept([FromQuery] int conceptId, long ownerId)
        {
            return ReturnValueOrError(_conceptService.DeleteConcept(conceptId, ownerId));
        }
    }
}
