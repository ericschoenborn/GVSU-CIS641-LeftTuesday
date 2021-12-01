using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class TaskService
    {
        private TaskRepository _taskRepo;

        public TaskService(TaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public (Exception, TaskObj) GetTask(int taskId)
        {
            //Todo add validation
            return _taskRepo.GetTask(taskId);
        }

        public (Exception, List<TaskObj>) GetTasks()
        {
            //Todo add validation
            return _taskRepo.GetTasks();
        }

        public (Exception, long) CreateTask(TaskObj task)
        {
            //Todo add validation

            return _taskRepo.AddTask(task);
        }

        public (Exception, TaskObj) UpdateTask(TaskObj task)
        {
            //Todo add validation
            var (error, original) = _taskRepo.GetTask(task.Id);

            if (error != null)
            {
                return (error, null);
            }

            if (original == null)
            {
                return (new Exception($"Task not found with id {task.Id}"), null);
            }

            if (!string.IsNullOrWhiteSpace(task.Name))
            {
                original.Name = task.Name;
            }

            if (!string.IsNullOrWhiteSpace(task.Description))
            {
                original.Description = task.Description;
            }

            return _taskRepo.UpdateTask(original);
        }

        public (Exception, bool) DeleteTask(int taskId)
        {
            //Todo cascade delete?
            return _taskRepo.DeleteTask(taskId);
        }
    }
}
