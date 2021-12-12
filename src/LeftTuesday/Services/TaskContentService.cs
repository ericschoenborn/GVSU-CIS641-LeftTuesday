using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class TaskContentService
    {
        private TaskContentRepository _taskContentRepo;
        private readonly TaskRepository _taskRepo;
        private ContentRepository _contentRepo;

        public TaskContentService(TaskContentRepository taskContentRepo,
            TaskRepository taskRepo,
            ContentRepository contentRepo)
        {
            _taskContentRepo = taskContentRepo;
            _taskRepo = taskRepo;
            _contentRepo = contentRepo;
        }

        public (Exception, List<TaskContent>) GetTaskContents(long taskId)
        {
            if (taskId == default)
            {
                return (new Exception("No Task ID given."), null);
            }

            var (taskError, content) = _taskRepo.GetTask(taskId);

            if (content == null || taskError != null)
            {
                return (taskError ?? new Exception($"No Task found with id {taskId}"), null);
            }

            return _taskContentRepo.GetTaskContent(taskId);
        }

        public (Exception, List<TaskContent>) GetAllTaskContents()
        {
            return _taskContentRepo.GetAllTaskContent();
        }

        public (Exception, bool) AddTaskContent(long taskId, long contentId)
        {
            if (taskId == default)
            {
                return (new Exception("No Task ID given."), false);
            }

            if (contentId == default)
            {
                return (new Exception("No Content ID given."), false);
            }

            var (taskError, taskContents) = GetTaskContents(taskId);

            if (taskError != null)
            {
                return (taskError, false);
            }

            if (taskContents.Exists(e => e.Task == taskId))
            {
                return (null, true);
            }

            var (findTaskError, task) = _contentRepo.GetContent(contentId);

            if (findTaskError != null || task == null)
            {
                return (findTaskError ?? new Exception($"No Content found with id {contentId}"), false);
            }

            var (error, _) = _taskContentRepo.Add(taskId, contentId);

            return (error, error == null);
        }

        public (Exception, bool) DeleteTaskContent(long taskId, long contentId)
        {
            return _taskContentRepo.DeleteTaskContent(taskId, contentId);
        }
    }
}
