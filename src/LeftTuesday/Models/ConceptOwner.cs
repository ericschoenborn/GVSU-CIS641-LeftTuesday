using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class ConceptOwner
    {
        public ConceptOwner() { }

        public ConceptOwner(ConceptOwner t)
        {
            Id = t.Id;
            Concept = t.Concept;
            Owner = t.Owner;
        }

        public int Id { get; set; }

        public int Concept { get; set; }

        public int Owner { get; set; }
    }
}
