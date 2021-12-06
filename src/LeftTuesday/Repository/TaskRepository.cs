using LeftTuesday.Models;
using System;
using System.Collections.Generic;

namespace LeftTuesday.Repository
{
    public class TaskRepository
    {
        public (Exception, List<TaskObj>) GetTasks()
        {
            var cmdString = @$"Select * From task;";
            return SqlHelper.QueryMany<TaskObj>(cmdString);
        }


        public (Exception, TaskObj) GetTask(long taskId)
        {
            var cmdString = @$"Select * From task WHERE id = {taskId}";
            return SqlHelper.QuerySingle<TaskObj>(cmdString);
        }

        public (Exception, long) AddTask(TaskObj task)
        {
            var cmdString = @$"INSERT INTO task
                                (name,description) 
                               VALUES
                                ('{task.Name}','{task.Description}')
                               ;SELECT LAST_INSERT_ID();";

            return SqlHelper.Insert(cmdString);
        }

        public (Exception, TaskObj) UpdateTask(TaskObj task)
        {
            var cmdString = @$"UPDATE task
                                SET name='{task.Name}',
                                description='{task.Description}'
                                WHERE id='{task.Id}';";

            return (SqlHelper.NonQuery(cmdString), task);
        }

        public (Exception, bool) DeleteTask(int id)
        {
            var cmdString = @$"DELETE FROM task WHERE id ={id}";
            return (SqlHelper.NonQuery(cmdString), true);
        }
    }
}
