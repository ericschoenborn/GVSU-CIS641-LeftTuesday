using LeftTuesday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Repository
{
    public class ConceptRepository
    {
        public (Exception, long) AddConcpet(Concept concept)
        {
            var cmdString = @$"INSERT INTO concept
                                (name,description) 
                               VALUES
                                ('{concept.Name}','{concept.Description}')
                               ;SELECT LAST_INSERT_ID();";
            return SqlHelper.Insert(cmdString);
        }

        public (Exception, Concept) GetConcpet(long conceptId)
        {
            var cmdString = @$"Select * From concept WHERE id = {conceptId}";
            return SqlHelper.QuerySingle<Concept>(cmdString);
        }

        public (Exception, List<Concept>) GetConcpets()
        {
            var cmdString = @$"Select * From concept;";
            return SqlHelper.QueryMany<Concept>(cmdString);
        }

        public (Exception, Concept) UpdateConcpet(Concept concept)
        {
            var cmdString = @$"UPDATE concept
                                SET name='{concept.Name}',
                                description='{concept.Description}'
                                WHERE id='{concept.Id}';";

            return (SqlHelper.NonQuery(cmdString), concept);
        }

        public (Exception, bool) DeleteConcpet(int id)
        {
            var cmdString = @$"DELETE FROM concept WHERE id ={id}";
            return (SqlHelper.NonQuery(cmdString), true);
        }
    }
}
