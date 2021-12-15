using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class IsOwnerService
    {
        private ConceptRepository _conceptRepo;
        private readonly SessionRepository _sessionRepo;

        public IsOwnerService(
            ConceptRepository conceptRepository,
            SessionRepository sessionRepo)
        {
            _conceptRepo = conceptRepository;
            _sessionRepo = sessionRepo;
        }

        public bool IsSessionOwner(long sessionId, long userId)
        {
            var (conceptError, session) = _sessionRepo.GetSession(sessionId);

            if (conceptError != null || session == null)
            {
                return false;
            }

            var (error, conceptOwners) = _conceptRepo.GetConcpetOwners(session.Concept);

            if (error != null)
            {
                return false;
            }

            return conceptOwners.Exists(e => e.Owner == userId);
        }

        public bool IsConceptOwner(int conceptId, long userId)
        {
            var (error, conceptOwners) = _conceptRepo.GetConcpetOwners(conceptId);

            if (error != null)
            {
                return false;
            }

            return conceptOwners.Any(e => e.Owner == userId);
        }
    }
}
