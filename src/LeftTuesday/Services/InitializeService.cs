using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class InitializeService
    {
        private InitializeRepository init;

        public InitializeService()
        {
            init = new InitializeRepository();
        }

        public Exception InitializeDatabase()
        {
            Exception error = null;
            SqlHelper.SetConnection();
            var ini = new InitializeRepository();
            error = ini.EnsureDatabase();
            if(error != null)
            {
                return error;
            }

            error = SqlHelper.SetDatabase("lefttuesday");
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureUserTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureConceptTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureTaskTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureConceptTaskTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureContentTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureTaskContentTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureSessionTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureSessionLeaderTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureSessionParticipantTable();
            if (error != null)
            {
                return error;
            }

            error = ini.EnsureConceptOwnerTable();
            if (error != null)
            {
                return error;
            }
          
            error = ini.EnsureCompletedTaskTable();
            if (error != null)
            {
                return error;
            }

            return null;
        }
    }
}
