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
            return ReturnValueOrError(_conceptTaskService.GetAllConceptTasks());
        }

        [HttpGet("allconcept")]
        public IActionResult GetAllForConcept([FromQuery] long conceptId)
        {
            return ReturnValueOrError(_conceptTaskService.GetConceptTasks(conceptId));
        }

        [HttpPost("add")]
        public IActionResult AddConceptTask([FromQuery] long conceptId, [FromQuery] long taskId)
        {
            return ReturnValueOrError(_conceptTaskService.AddConceptTask(conceptId, taskId));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteConceptTask([FromQuery] long conceptId, [FromQuery] long taskId)
        {
            return ReturnValueOrError(_conceptTaskService.DeleteConceptTask(conceptId, taskId));
        }
    }
}
