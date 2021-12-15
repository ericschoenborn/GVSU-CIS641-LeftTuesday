using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class SessionParticipantService
    {
        private SessionParticipantRepository _sessionParticipantRepo;
        private readonly SessionRepository _sessionRepo;
        private UserRepository _userRepo;
        private IsOwnerService _isOwnerService;

        public SessionParticipantService(SessionParticipantRepository sessionParticipantRepo,
            SessionRepository sessionRepo,
            UserRepository userRepo,
            IsOwnerService isOwnerService)
        {
            _sessionParticipantRepo = sessionParticipantRepo;
            _sessionRepo = sessionRepo;
            _userRepo = userRepo;
            _isOwnerService = isOwnerService;
        }

        public (Exception, List<SessionParticipant>) GetSessionParticipants(long sessionId, long ownerId)
        {
            if(!_isOwnerService.IsSessionOwner(sessionId, ownerId))
            {
                return (new Exception("Verification failed"), null);
            }

            if (sessionId == default)
            {
                return (new Exception("No Session ID given."), null);
            }

            var (conceptError, session) = _sessionRepo.GetSession(sessionId);

            if (session == null || conceptError != null)
            {
                return (conceptError ?? new Exception($"No Session found with id {sessionId}"), null);
            }

            return _sessionParticipantRepo.GetSessionParticipant(sessionId);
        }

        public (Exception, List<SessionParticipant>) GetAllSessionParticipant()
        {
            return _sessionParticipantRepo.GetAllSessionParticipants();
        }

        public (Exception, bool) AddSessionParticipant(long sessionId, long participantId, long ownerId)
        {
            if (sessionId == default)
            {
                return (new Exception("No Session ID given."), false);
            }

            if (participantId == default)
            {
                return (new Exception("No Participant ID given."), false);
            }

            var (sessionError, conceptTasks) = GetSessionParticipants(sessionId, ownerId);

            if (sessionError != null)
            {
                return (sessionError, false);
            }

            if (conceptTasks.Exists(e => e.Participant == participantId))
            {
                return (null, true);
            }

            var (findUserError, task) = _userRepo.GetUserById(participantId);

            if (findUserError != null || task == null)
            {
                return (findUserError ?? new Exception($"No User found with id {participantId}"), false);
            }

            var (error, _) = _sessionParticipantRepo.Add(sessionId, participantId);

            return (error, error == null);
        }

        public (Exception, bool) DeleteConceptTask(long sessionId, long participantId, long ownerId)
        {
            if (!_isOwnerService.IsSessionOwner(sessionId, ownerId))
            {
                return (new Exception("Verification failed"), false);
            }

            return _sessionParticipantRepo.DeleteSessionParticipant(sessionId, participantId);
        }
    }
}
