using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class SessionService
    {
        private SessionRepository _sessionRepository;

        public SessionService(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public (Exception, long) CreateSession(Session session, int userId)
        {
            //Todo add validation

            return _sessionRepository.AddSession(session);
        }

        public (Exception, Session) GetSession(int sessionId)
        {
            //Todo add validation
            return _sessionRepository.GetSession(sessionId);
        }

        public (Exception, List<Session>) GetSessions()
        {
            //Todo add validation
            return _sessionRepository.GetSessions();
        }

        public (Exception, Session) UpdateSession(Session session)
        {
            //Todo add validation
            var (error, original) = _sessionRepository.GetSession(session.Id);

            if (error != null)
            {
                return (error, null);
            }

            if (original == null)
            {
                return (new Exception($"Session not found with id {session.Id}"), null);
            }

            if (!string.IsNullOrWhiteSpace(session.Name))
            {
                original.Name = session.Name;
            }

            if (!string.IsNullOrWhiteSpace(session.Description))
            {
                original.Description = session.Description;
            }

            if (session.Start != default)
            {
                original.Start = session.Start;
            }

            if (session.End != default)
            {
                original.End = session.End;
            }

            return _sessionRepository.UpdateSession(session);
        }

        public (Exception, bool) DeleteSession(int sessionId)
        {
            //Todo cascade delete?
            return _sessionRepository.DeleteSession(sessionId);
        }
    }
}
