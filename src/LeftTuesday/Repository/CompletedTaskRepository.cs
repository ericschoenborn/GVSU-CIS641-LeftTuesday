using LeftTuesday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Repository
{
    public class CompletedTaskRepository
    {
        public (Exception, long) Add(CompletedTask completedTask)
        {
            var cmdString = @$"INSERT INTO completed_task
                                (session,participant,task) 
                               VALUES
                                ({completedTask.Session},{completedTask.Participant},{completedTask.Task})
                               ;SELECT LAST_INSERT_ID();";

            return SqlHelper.Insert(cmdString);
        }

        public (Exception, CompletedTask) GetConceptTaskById(long completedTaskId)
        {
            var cmdString = @$"Select * From completed_task WHERE id = {completedTaskId};";
            return SqlHelper.QuerySingle<CompletedTask>(cmdString);
        }

        public (Exception, List<CompletedTask>) GetConceptTasksBySession(long sessionId)
        {
            var cmdString = @$"Select * From completed_task WHERE session = {sessionId};";
            return SqlHelper.QueryMany<CompletedTask>(cmdString);
        }

        public (Exception, List<CompletedTask>) GetConceptTasksByParticipant(long participantId)
        {
            var cmdString = @$"Select * From completed_task WHERE participant = {participantId};";
            return SqlHelper.QueryMany<CompletedTask>(cmdString);
        }

        public (Exception, List<CompletedTask>) GetConceptTasksByTask(long taskId)
        {
            var cmdString = @$"Select * From completed_task WHERE task = {taskId};";
            return SqlHelper.QueryMany<CompletedTask>(cmdString);
        }

        public (Exception, List<CompletedTask>) GetAllCompletedTasks()
        {
            var cmdString = @$"Select * From completed_task";
            return SqlHelper.QueryMany<CompletedTask>(cmdString);
        } 

        public (Exception, bool) DeleteCompletedTask(long completedTaskId)
        {
            var cmdString = @$"DELETE FROM completed_task WHERE id = {completedTaskId}";
            return (SqlHelper.NonQuery(cmdString), true);
        }
    }
}
