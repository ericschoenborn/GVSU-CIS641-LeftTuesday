using LeftTuesday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Repository
{
    public class SessionParticipantRepository
    {
        public (Exception, long) Add(long sessionId, long participantId)
        {
            var cmdString = @$"INSERT INTO session_participant
                                (session,participant) 
                               VALUES
                                ('{sessionId}','{participantId}')
                               ;SELECT LAST_INSERT_ID();";

            return SqlHelper.Insert(cmdString);
        }

        public (Exception, List<SessionParticipant>) GetSessionParticipant(long sessionId)
        {
            var cmdString = @$"Select * From session_participant WHERE session = {sessionId};";
            return SqlHelper.QueryMany<SessionParticipant>(cmdString);
        }

        public (Exception, List<SessionParticipant>) GetAllSessionParticipants()
        {
            var cmdString = @$"Select * From session_participant";
            return SqlHelper.QueryMany<SessionParticipant>(cmdString);
        }

        public (Exception, bool) DeleteSessionParticipant(long sessionId, long participantId)
        {
            var cmdString = @$"DELETE FROM session_participant WHERE session ={sessionId} AND participant = {participantId}";
            return (SqlHelper.NonQuery(cmdString), true);
        }
    }
}
