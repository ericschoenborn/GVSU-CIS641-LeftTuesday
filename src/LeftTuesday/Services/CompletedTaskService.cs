using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class CompletedTaskService
    {
        private readonly CompletedTaskRepository _completedTaskRepo;
        private readonly SessionRepository _sessionRepo;
        private readonly SessionParticipantRepository _sessionParticipantRepo;
        private readonly ConceptTaskRepository _conceptTaskRepo;
        private readonly IsOwnerService _isOwnerService;

        public CompletedTaskService(CompletedTaskRepository completedTaskRepo,
            SessionRepository sessionRepo,
            SessionParticipantRepository sessionParticipantRepo,
            ConceptTaskRepository conceptTaskRepo,
            IsOwnerService isOwnerService)
        {
            _completedTaskRepo = completedTaskRepo;
            _sessionRepo = sessionRepo;
            _sessionParticipantRepo = sessionParticipantRepo;
            _conceptTaskRepo = conceptTaskRepo;
            _isOwnerService = isOwnerService;
        }

        public (Exception, List<CompletedTask>) GetCompletedTaskBySession(long sessionId, long ownerId)
        {
            if (!_isOwnerService.IsSessionOwner(sessionId, ownerId))
            {
                return (new Exception("Verification failed"), null);
            }

            return _completedTaskRepo.GetConceptTasksBySession(sessionId);
        }

        public (Exception, List<CompletedTask>) GetCompletedTaskByParticipant(long sessionId, long ownerId, long participantId)
        {
            if (!_isOwnerService.IsSessionOwner(sessionId, ownerId))
            {
                return (new Exception("Verification failed"), null);
            }

            return _completedTaskRepo.GetConceptTasksByParticipant(participantId);
        }

        public (Exception, List<CompletedTask>) GetCompletedTaskByTask(long sessionId, long ownerId, long taskId)
        {
            if (!_isOwnerService.IsSessionOwner(sessionId, ownerId))
            {
                return (new Exception("Verification failed"), null);
            }

            return _completedTaskRepo.GetConceptTasksByTask(taskId);
        }

        public (Exception, CompletedTask) GetCompletedTaskById(long completedTaskId)
        {
            return _completedTaskRepo.GetConceptTaskById(completedTaskId);
        }

        public (Exception, List<ConceptTask>) GetAllCompletedTasks()
        {
            return _conceptTaskRepo.GetAllConceptTasks();
        }

        public (Exception, bool) AddCompletedTask(CompletedTask completedTask, long ownerId)
        {
            if (!_isOwnerService.IsSessionOwner(completedTask.Session, ownerId))
            {
                return (new Exception("Verification failed"), false);
            }

            if (completedTask.Session == default)
            {
                return (new Exception("No Session ID given."), false);
            }

            if (completedTask.Participant == default)
            {
                return (new Exception("No Participant ID given."), false);
            }

            if (completedTask.Task == default)
            {
                return (new Exception("No Participant ID given."), false);
            }

            var (getSessionError, session) = _sessionRepo.GetSession(completedTask.Session);

            if (getSessionError != null || session == null)
            {
                return (getSessionError == null? new Exception($"Session does not exist with id {completedTask.Session}"): getSessionError, false);
            }

            var (getTaskError, conceptTasks) = _conceptTaskRepo.GetConceptTasks(session.Concept);

            if (getTaskError != null || !conceptTasks.Exists(e => e.Task == completedTask.Task))
            {
                return (getTaskError == null? new Exception($"Task does not exist with id {completedTask.Task}") : getTaskError, true);
            }

            var (getParticipantError, participants) = _sessionParticipantRepo.GetSessionParticipant(completedTask.Session);

            if (getParticipantError != null || !participants.Exists(e => e.Participant == completedTask.Participant))
            {
                return (getParticipantError ?? new Exception($"No Participant found with id {completedTask.Participant}"), false);
            }

            var (error, _) = _completedTaskRepo.Add(completedTask);

            return (error, error == null);
        }

        public (Exception, bool) DeleteConceptTask(long completedTaskId, long sessionId, long ownerId)
        {
            if (!_isOwnerService.IsSessionOwner(sessionId, ownerId))
            {
                return (new Exception("Verification failed"), false);
            }

            return _completedTaskRepo.DeleteCompletedTask(completedTaskId);
        }
    }
}
