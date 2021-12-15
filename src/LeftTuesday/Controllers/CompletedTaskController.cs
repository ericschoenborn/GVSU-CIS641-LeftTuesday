using LeftTuesday.Models;
using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeftTuesday.Controllers
{
    [Route("Completed/Task")]
    public class CompletedTaskController : BaseController
    {
        private readonly CompletedTaskService _completedTaskService;

        public CompletedTaskController(CompletedTaskService completedTaskService)
        {
            _completedTaskService = completedTaskService;
        }

        [HttpGet("getbysession/{ownerId}")]
        public IActionResult GetBySession([FromQuery] long sessionId, long ownerId)
        {
            return ReturnValueOrError(_completedTaskService.GetCompletedTaskBySession(sessionId, ownerId));
        }

        [HttpGet("getbytask/{ownerId}")]
        public IActionResult GetByTask([FromQuery] long sessionId, [FromQuery] long taskId, long ownerId)
        {
            return ReturnValueOrError(_completedTaskService.GetCompletedTaskByTask(sessionId, ownerId, taskId));
        }

        [HttpGet("getbyid/{ownerId}")]
        public IActionResult GetByTask([FromQuery] long completedTaskId)
        {
            return ReturnValueOrError(_completedTaskService.GetCompletedTaskById(completedTaskId));
        }

        [HttpGet("getAll")]
        public IActionResult GetByTask()
        {
            return ReturnValueOrError(_completedTaskService.GetAllCompletedTasks());
        }

        [HttpGet("getbyparticipant/{ownerId}")]
        public IActionResult GetByParticipant([FromQuery] long sessionId, [FromQuery] long participantId, long ownerId)
        {
            return ReturnValueOrError(_completedTaskService.GetCompletedTaskByParticipant(sessionId, ownerId, participantId));
        }

        [HttpPost("add/{ownerId}")]
        public IActionResult CompleteTask([FromBody] CompletedTask completedTask, long ownerId)
        {
            return ReturnValueOrError(_completedTaskService.AddCompletedTask(completedTask, ownerId));
        }

        [HttpDelete("delete/{ownerId}")]
        public IActionResult CompleteTask([FromQuery] long completedTaskId, [FromQuery] long sessionId, long ownerId)
        {
            return ReturnValueOrError(_completedTaskService.DeleteConceptTask(completedTaskId, sessionId, ownerId));
        }
    }
}
