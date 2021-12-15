using LeftTuesday.Models;
using LeftTuesday.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Services
{
    public class ConceptService
    {
        private ConceptRepository _conceptRepo;
        private IsOwnerService _isOwnerService;

        public ConceptService(ConceptRepository concpetRepo,
            IsOwnerService isOwnerService)
        {
            _conceptRepo = concpetRepo;
            _isOwnerService = isOwnerService;
        }

        public (Exception, long) CreateConcept(Concept concept, long ownerId)
        {     
            var(error, conceptId) = _conceptRepo.AddConcpet(concept);
            if(error != null)
            {
                return (error, default);
            }

            return _conceptRepo.AddOwner(conceptId, ownerId);
        }

        public (Exception, Concept) GetConcept(int conceptId, long ownerId)
        {
            if(!_isOwnerService.IsConceptOwner(conceptId, ownerId))
            {
                return (new Exception("Verification failed"), null);
            }

            return _conceptRepo.GetConcpet(conceptId);
        }

        public (Exception, List<Concept>) GetConcepts()
        {
            return _conceptRepo.GetConcpets();
        }

        public (Exception, List<ConceptOwner>) GetAllConceptOwners()
        {
            return _conceptRepo.GetAllConcpetOwners();
        }

        public (Exception, Concept) UpdateConcept(Concept concept, long ownerId)
        {
            if (!_isOwnerService.IsConceptOwner(concept.Id, ownerId))
            {
                return (new Exception("Verification failed"), null);
            }

            var (error, original) = _conceptRepo.GetConcpet(concept.Id);

            if(error!= null)
            {
                return (error, null);
            }

            if(original == null)
            {
                return (new Exception($"Concept not found with id {concept.Id}"), null);
            }

            if (!string.IsNullOrWhiteSpace(concept.Name))
            {
                original.Name = concept.Name;
            }

            if (!string.IsNullOrWhiteSpace(concept.Description))
            {
                original.Description = concept.Description;
            }

            return _conceptRepo.UpdateConcpet(original);
        }

        public (Exception, bool) DeleteConcept(int conceptId, long ownerId)
        {
            if (!_isOwnerService.IsConceptOwner(conceptId, ownerId))
            {
                return (new Exception("Verification failed"), false);
            }
            //Todo cascade delete?
            return _conceptRepo.DeleteConcpet(conceptId);
        }
    }
}
