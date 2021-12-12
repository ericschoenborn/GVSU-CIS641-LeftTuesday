using LeftTuesday.Models;
using System;
using System.Collections.Generic;

namespace LeftTuesday.Repository
{
    public class TaskContentRepository
    {
        public (Exception, long) Add(long taskId, long contentId)
        {
            var cmdString = @$"INSERT INTO task_content
                                (task,content) 
                               VALUES
                                ('{taskId}','{contentId}')
                               ;SELECT LAST_INSERT_ID();";

            return SqlHelper.Insert(cmdString);
        }

        public (Exception, List<TaskContent>) GetTaskContent(long taskId)
        {
            var cmdString = @$"Select * From task_content WHERE task = {taskId};";
            return SqlHelper.QueryMany<TaskContent>(cmdString);
        }

        public (Exception, List<TaskContent>) GetAllTaskContent()
        {
            var cmdString = @$"Select * From task_content";
            return SqlHelper.QueryMany<TaskContent>(cmdString);
        }

        public (Exception, bool) DeleteTaskContent(long taskId, long contentId)
        {
            var cmdString = @$"DELETE FROM task_content WHERE task ={taskId} AND content = {taskId}";
            return (SqlHelper.NonQuery(cmdString), true);
        }
    }
}
