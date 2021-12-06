using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Controllers
{
    [Route("Concept/Task")]
    public class ConceptTaskController : BaseController
    {
        private readonly ConceptTaskService _conceptTaskService;

        public ConceptTaskController(ConceptTaskService conceptTaskService)
        {
            _conceptTaskService = conceptTaskService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return ReturnValueOrError(_conceptTaskService.GetConceptTasks());
        }

        [HttpGet("allconcept")]
        public IActionResult GetAllForConcept([FromQuery] long conceptId)
        {
            return ReturnValueOrError(_conceptTaskService.GetConceptTasks(conceptId));
        }

        [HttpPost("addMany")]
        public IActionResult AddMany([FromQuery] long conceptId, [FromQuery] List<long> taskIds)
        {
            return ReturnValueOrError(_conceptTaskService.AddMany(conceptId, taskIds));
        }
    }
}
