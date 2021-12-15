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
        private ConceptRepository _conceptRepo;

        public SessionParticipantService(SessionParticipantRepository sessionParticipantRepo,
            SessionRepository sessionRepo,
            UserRepository userRepo,
            ConceptRepository conceptRepository)
        {
            _sessionParticipantRepo = sessionParticipantRepo;
            _sessionRepo = sessionRepo;
            _userRepo = userRepo;
            _conceptRepo = conceptRepository;
        }

        private bool IsOwner(long sessionId, long userId)
        {
            var (conceptError, session) = _sessionRepo.GetSession(sessionId);

            if(conceptError != null)
            {
                return false;
            }

            var (error, conceptOwners) = _conceptRepo.GetConcpetOwners(session.Concept);

            if (error != null)
            {
                return false;
            }

            return conceptOwners.Any(e => e.Owner == userId);
        }

        public (Exception, List<SessionParticipant>) GetSessionParticipants(long sessionId, long userId)
        {
            if (sessionId == default)
            {
                return (new Exception("No Session ID given."), null);
            }

            var (conceptError, concept) = _sessionRepo.GetSession(sessionId);

            if (concept == null || conceptError != null)
            {
                return (conceptError ?? new Exception($"No Session found with id {sessionId}"), null);
            }

            return _sessionParticipantRepo.GetSessionParticipant(sessionId);
        }

        public (Exception, List<ConceptTask>) GetAllConceptTasks()
        {
            return _conceptTaskRepo.GetAllConceptTasks();
        }

        public (Exception, bool) AddConceptTask(long conceptId, long taskId)
        {
            if (conceptId == default)
            {
                return (new Exception("No Concept ID given."), false);
            }

            if (conceptId == default)
            {
                return (new Exception("No Concept ID given."), false);
            }

            var (conceptError, conceptTasks) = GetConceptTasks(conceptId);

            if (conceptError != null)
            {
                return (conceptError, false);
            }

            if (conceptTasks.Exists(e => e.Task == taskId))
            {
                return (null, true);
            }

            var (findTaskError, task) = _taskRepo.GetTask(taskId);

            if (findTaskError != null || task == null)
            {
                return (findTaskError ?? new Exception($"No Task found with id {taskId}"), false);
            }

            var (error, _) = _conceptTaskRepo.Add(conceptId, taskId);

            return (error, error == null);
        }

        public (Exception, bool) DeleteConceptTask(long conceptId, long taskId)
        {
            return _conceptTaskRepo.DeleteConcpetTask(conceptId, taskId);
        }
    }
}
