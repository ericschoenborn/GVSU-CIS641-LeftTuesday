using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeftTuesday.Controllers
{
    [Route("Task/Content")]
    public class TaskContentController : BaseController
    {
        private readonly TaskContentService _taskContentService;

        public TaskContentController(TaskContentService taskContentService)
        {
            _taskContentService = taskContentService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return ReturnValueOrError(_taskContentService.GetAllTaskContents());
        }

        [HttpGet("alltask")]
        public IActionResult GetAllForTask([FromQuery] long taskId)
        {
            return ReturnValueOrError(_taskContentService.GetTaskContents(taskId));
        }

        [HttpPost("add")]
        public IActionResult AddTaskContent([FromQuery] long taskId, [FromQuery] long contentId)
        {
            return ReturnValueOrError(_taskContentService.AddTaskContent(taskId, contentId));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteTaskContent([FromQuery] long taskId, [FromQuery] long contentId)
        {
            return ReturnValueOrError(_taskContentService.DeleteTaskContent(taskId, contentId));
        }
    }
}
