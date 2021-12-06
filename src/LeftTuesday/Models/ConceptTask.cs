using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class ConceptTask
    {
        public ConceptTask() { }

        public ConceptTask(ConceptTask t)
        {
            Id = t.Id;
            Concept = t.Concept;
            Task = t.Task;
        }

        public int Id { get; set; }

        public int Concept { get; set; }

        public int Task { get; set; }
    }
}
