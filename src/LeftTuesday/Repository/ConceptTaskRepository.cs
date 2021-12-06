using LeftTuesday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Repository
{
    public class ConceptTaskRepository
    {
        public (Exception, long) Add(long conceptId, long taskId)
        {
            var cmdString = @$"INSERT INTO concept_task
                                (concept,task) 
                               VALUES
                                ('{conceptId}','{taskId}')
                               ;SELECT LAST_INSERT_ID();";

            return SqlHelper.Insert(cmdString);
        }

        internal (Exception, List<ConceptTask>) GetConceptTasks(long conceptId)
        {
            var cmdString = @$"Select * From concept_task WHERE concept = {conceptId};";
            return SqlHelper.QueryMany<ConceptTask>(cmdString);
        }
    }
}
