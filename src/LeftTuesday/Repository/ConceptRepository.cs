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

        public (Exception, Concept) GetConcpet(int conceptId)
        {
            var cmdString = @$"Select * From concept WHERE id = {conceptId}";
            return SqlHelper.Query<Concept>(cmdString);
        }

        public (Exception, Concept) UpdateConcpet(Concept concept)
        {
            throw new NotImplementedException("get this done");
            var cmdString = @$";";
            return SqlHelper.Query<Concept>(cmdString);
        }

        public (Exception, bool) DeleteConcpet(int id)
        {
            throw new NotImplementedException("get this done");
            var cmdString = @$";";
            return (null, true);
        }
    }
}
