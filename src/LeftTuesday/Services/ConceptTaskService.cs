using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class ConceptTaskService
    {
        private ConceptTaskRepository _conceptTaskRepo;
        private readonly ConceptRepository _conceptRepo;
        private TaskRepository _taskRepo;

        public ConceptTaskService(ConceptTaskRepository concpetTaskRepo, 
            TaskRepository taskRepo,
            ConceptRepository conceptRepo)
        {
            _conceptTaskRepo = concpetTaskRepo;
            _taskRepo = taskRepo;
            _conceptRepo = conceptRepo;
        }

        public (Exception, List<ConceptTask>) GetConceptTasks(long conceptId)
        {
            if (conceptId == default)
            {
                return (new Exception("No Concept ID given."), null);
            }

            var (conceptError, concept) = _conceptRepo.GetConcpet(conceptId);

            if (concept == null || conceptError != null)
            {
                return (conceptError ?? new Exception($"No Concept found with id {conceptId}"), null);
            }

            return _conceptTaskRepo.GetConceptTasks(conceptId);
        }

        public (Exception, List<ConceptTask>) GetAllConceptTasks()
        {
            return _conceptTaskRepo.GetAllConceptTasks();
        }

        public (Exception, bool) AddConceptTask(long conceptId, long taskId)
        {
            if(conceptId == default)
            {
                return (new Exception("No Concept ID given."), false);
            }

            if (conceptId == default)
            {
                return (new Exception("No Concept ID given."), false);
            }

            var (conceptError, conceptTasks) = GetConceptTasks(conceptId);

            if(conceptError != null)
            {
                return (conceptError, false);
            }

            if(conceptTasks.Exists(e => e.Task == taskId))
            {
                return (null, true);
            }

            var (findTaskError, task) = _taskRepo.GetTask(taskId);

            if(findTaskError != null || task == null)
            {
                return(findTaskError ?? new Exception($"No Task found with id {taskId}"), false);
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
