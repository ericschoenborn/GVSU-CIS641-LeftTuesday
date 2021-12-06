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

        internal (Exception error, List<ConceptTask> value) GetConceptTasks()
        {
            throw new NotImplementedException();
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

        public (List<Exception>, bool) AddMany(long conceptId, List<long> taskIds)
        {
            if(conceptId == default)
            {
                return (new List<Exception> { new Exception("No Concept ID given.") }, false);
            }

            var (conceptError, conceptTasks) = GetConceptTasks(conceptId);

            if(conceptError != null)
            {
                return (new List<Exception> { conceptError }, false);
            }

            var exceptions = new List<Exception>();

            var acceptedTaskIds = taskIds.Where(e => !conceptTasks.Exists(c => c.Task == e) && e != default);

            foreach (var taskId in acceptedTaskIds)
            {
                var (findTaskError, task) = _taskRepo.GetTask(taskId);

                if(findTaskError != null || task == null)
                {
                    exceptions.Add(findTaskError ?? new Exception($"No Task found with id {taskId}"));
                    continue;
                }

                var (error, _) = _conceptTaskRepo.Add(conceptId, taskId);

                if(error != null)
                {
                    exceptions.Add(error);
                }
            }

            var moo = exceptions.Any();

            return (exceptions, moo);
        }
    }
}
