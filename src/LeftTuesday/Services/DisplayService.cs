using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class DisplayService
    {
        public readonly ConceptRepository _conceptRepo;
        public readonly ConceptTaskRepository _conceptTaskRepo;
        public readonly TaskRepository _taskRepo;
        public readonly TaskContentRepository _taskContentRepo;
        public readonly ContentRepository _contentRepo;
        public readonly UserRepository _userRepo;
        public readonly SessionRepository _sessionRepo;
        public readonly SessionParticipantRepository _sessionParticipantRepo;
        public readonly CompletedTaskRepository _completedTaskRepo;

        public DisplayService(ConceptRepository conceptRepo,
            ConceptTaskRepository conceptTaskRepo,
            TaskRepository taskRepo, 
            TaskContentRepository taskContentRepo,
            ContentRepository contentRepo,
            UserRepository userRepo,
            SessionRepository sessionRepo,
            SessionParticipantRepository sessionParticipantRepo,
            CompletedTaskRepository completedTaskRepo)
        {
            _conceptRepo = conceptRepo;
            _conceptTaskRepo = conceptTaskRepo;
            _taskRepo = taskRepo;
            _taskContentRepo = taskContentRepo;
            _contentRepo = contentRepo;
            _userRepo = userRepo;
            _sessionRepo = sessionRepo;
            _sessionParticipantRepo = sessionParticipantRepo;
            _completedTaskRepo = completedTaskRepo;
        }

        public (Exception, ShowEveryting) GetEverything(long sesisonId)
        {
            var everything = new ShowEveryting
            {
                Participants = new List<User>()
            };

            var (sessionError, session) = _sessionRepo.GetSession(sesisonId);
            if(sessionError != null || session == null)
            {
                return (null, null);
            }
            everything.Session = session;

            var (error, fullConcept) = GetFullConcept(session.Concept);
            if (error != null || fullConcept == null)
            {
                return (null, null);
            }

            everything.FullConcept = fullConcept;

            var (participantsError, participants) = _sessionParticipantRepo.GetSessionParticipant(sesisonId);
            if (participantsError != null)
            {
                return (null, null);
            }

            foreach(var parSet in participants)
            {
                var (userError, user) = _userRepo.GetUserById(parSet.Participant);
                if (participantsError != null)
                {
                    return (null, null);
                }
                everything.Participants.Add(user);
            }

            var (completedError, completeds) = _completedTaskRepo.GetConceptTasksBySession(sesisonId);
            if (completedError != null)
            {
                return (null, null);
            }

            everything.CompletedTasks = completeds;

            return (null, everything);
        }

        public (Exception, ShowFullConcept) GetFullConcept(long conceptId)
        {
            var fullConcept = new ShowFullConcept
            {
                Tasks = new List<DisplayTasks>()
            };

            var (conceptError, concept) = _conceptRepo.GetConcpet(conceptId);

            if(conceptError != null || concept == null)
            {
                return (null, null);
            }
            fullConcept.Concept = concept;

            var (conceptTaskError, conceptTasks) = _conceptTaskRepo.GetConceptTasks(conceptId);
            if (conceptTaskError != null)
            {
                return (null, null);
            }

            foreach(var idSet in conceptTasks)
            {
                var (taskError, task) = _taskRepo.GetTask(idSet.Task);
                if (taskError != null || task == null)
                {
                    return (null, null);
                }

                var (taskContentError, taskContent) = _taskContentRepo.GetTaskContent(task.Id);
                if (taskContentError != null)
                {
                    return (null, null);
                }

                var taskSet = new DisplayTasks
                {
                    Task = task,
                    Contents = new List<Content>()
                };

                foreach(var contentSet in taskContent)
                {
                    var (contentError, content) = _contentRepo.GetContent(contentSet.Content);
                    if (taskContentError != null)
                    {
                        return (null, null);
                    }
                    taskSet.Contents.Add(content);
                }

                fullConcept.Tasks.Add(taskSet);
            }

            var (error, conceptOwners) = _conceptRepo.GetConcpetOwners((int)conceptId);

            if (error != null)
            {
                return (null, null);
            }

            var (ownerError, owner) = _userRepo.GetUserById(conceptOwners.First().Owner);

            fullConcept.ConceptOwner = owner;

            return (null, fullConcept);
        }
    }
}
