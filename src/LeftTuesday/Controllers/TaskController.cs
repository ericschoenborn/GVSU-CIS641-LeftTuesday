using LeftTuesday.Models;
using LeftTuesday.Repository;
using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Controllers
{
    [Route("Task")]
    public class TaskController : BaseController
    {
        private TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("all")]
        public IActionResult GetAllTasks()
        {
            return ReturnValueOrError(_taskService.GetTasks());
        }

        [HttpGet("get")]
        public IActionResult GetTask([FromQuery] int taskId)
        {
            return ReturnValueOrError(_taskService.GetTask(taskId));
        }

        [HttpPost("create")]
        public IActionResult CreateTask([FromBody] TaskObj task)
        {
            return ReturnValueOrError(_taskService.CreateTask(task));
        }

        [HttpPut("update")]
        public IActionResult UpdateTask([FromBody] TaskObj task)
        {
            return ReturnValueOrError(_taskService.UpdateTask(task));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteTask([FromQuery] int taskId)
        {
            return ReturnValueOrError(_taskService.DeleteTask(taskId));
        }
    }
}
