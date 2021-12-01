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

        public ConceptService(ConceptRepository concpetRepo)
        {
            _conceptRepo = concpetRepo;
        }

        public (Exception, long) CreateConcept(Concept concept)
        {
            //Todo add validation

            return _conceptRepo.AddConcpet(concept);
        }

        public (Exception, Concept) GetConcept(int conceptId)
        {
            //Todo add validation
            return _conceptRepo.GetConcpet(conceptId);
        }

        public (Exception, List<Concept>) GetConcepts()
        {
            //Todo add validation
            return _conceptRepo.GetConcpets();
        }

        public (Exception, Concept) UpdateConcept(Concept concept)
        {
            //Todo add validation
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

        public (Exception, bool) DeleteConcept(int conceptId)
        {
            //Todo cascade delete?
            return _conceptRepo.DeleteConcpet(conceptId);
        }
    }
}
