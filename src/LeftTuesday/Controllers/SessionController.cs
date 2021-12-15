using LeftTuesday.Models;
using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeftTuesday.Controllers
{
    [Route("Session")]
    public class SessionController : BaseController
    {
        private readonly SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("all")]
        public IActionResult GetAllSessions()
        {
            return ReturnValueOrError(_sessionService.GetSessions());
        }

        [HttpGet("get")]
        public IActionResult GetSession([FromQuery] int sessionId)
        {
            return ReturnValueOrError(_sessionService.GetSession(sessionId));
        }

        [HttpPost("create/{id}")]
        public IActionResult CreateSession([FromBody] Session session, int id)
        {
            return ReturnValueOrError(_sessionService.CreateSession(session, id));
        }

        [HttpPut("update")]
        public IActionResult UpdateSession([FromBody] Session session)
        {
            return ReturnValueOrError(_sessionService.UpdateSession(session));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteSession([FromQuery] int conceptId)
        {
            return ReturnValueOrError(_sessionService.DeleteSession(conceptId));
        }
    }
}
