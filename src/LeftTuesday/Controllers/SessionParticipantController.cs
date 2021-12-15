using LeftTuesday.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Controllers
{
    [Route("Session/Participant")]
    public class SessionParticipantController : BaseController
    {
        private readonly SessionParticipantService _sessionParticipantService;

        public SessionParticipantController(SessionParticipantService sessionParticipantService)
        {
            _sessionParticipantService = sessionParticipantService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return ReturnValueOrError(_sessionParticipantService.GetAllSessionParticipant());
        }

        [HttpGet("allconcept/{ownerId}")]
        public IActionResult GetAllForConcept([FromQuery] long sessionId, long ownerId)
        {
            return ReturnValueOrError(_sessionParticipantService.GetSessionParticipants(sessionId, ownerId));
        }

        [HttpPost("add/{ownerId}")]
        public IActionResult AddConceptTask([FromQuery] long sessionId, [FromQuery] long participantId, long ownerId)
        {
            return ReturnValueOrError(_sessionParticipantService.AddSessionParticipant(sessionId, participantId, ownerId));
        }

        [HttpDelete("delete/{ownerId}")]
        public IActionResult DeleteConceptTask([FromQuery] long sessionId, [FromQuery] long participantId, long ownerId)
        {
            return ReturnValueOrError(_sessionParticipantService.DeleteConceptTask(sessionId, participantId, ownerId));
        }
    }
}
