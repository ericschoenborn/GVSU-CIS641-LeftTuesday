using LeftTuesday.Models;
using System;
using System.Collections.Generic;

namespace LeftTuesday.Repository
{
    public class SessionRepository
    {
        public (Exception, long) AddSession(Session session)
        {
            var cmdString = @$"INSERT INTO session
                                (name,concept,description,start,end) 
                               VALUES
                                ('{session.Name}',{session.Concept},'{session.Description}','{session.Start:yyyy-MM-dd}','{session.End:yyyy-MM-dd}')
                               ;SELECT LAST_INSERT_ID();";
            return SqlHelper.Insert(cmdString);
        }

        public (Exception, Session) GetSession(long sessionId)
        {
            var cmdString = @$"Select * From session WHERE id = {sessionId}";
            return SqlHelper.QuerySingle<Session>(cmdString);
        }

        public (Exception, List<Session>) GetSessions()
        {
            var cmdString = @$"Select * From session;";
            return SqlHelper.QueryMany<Session>(cmdString);
        }

        public (Exception, Session) UpdateSession(Session session)
        {
            var cmdString = @$"UPDATE session
                                SET name='{session.Name}',
                                concept={session.Concept},
                                description='{session.Description}',
                                start='{session.Start:yyyy-MM-dd}',
                                end='{session.End:yyyy-MM-dd}'
                                WHERE id='{session.Id}';";

            return (SqlHelper.NonQuery(cmdString), session);
        }

        public (Exception, bool) DeleteSession(int id)
        {
            var cmdString = @$"DELETE FROM session WHERE id ={id}";
            return (SqlHelper.NonQuery(cmdString), true);
        }
    }
}
