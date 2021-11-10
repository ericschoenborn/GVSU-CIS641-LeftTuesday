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

        public (Exception, Concept) UpdateConcept(Concept concept)
        {
            //Todo add validation
            return _conceptRepo.UpdateConcpet(concept);
        }

        public (Exception, bool) DeleteConcept(int conceptId)
        {
            //Todo cascade delete?
            return _conceptRepo.DeleteConcpet(conceptId);
        }
    }
}
