using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class ShowEveryting
    {
        public Session Session { get; set; }

        public ShowFullConcept FullConcept { get; set; }

        public List<User> Participants { get; set; }

        public List<CompletedTask> CompletedTasks { get; set; }
    }

    public class ShowFullConcept
    {
        public Concept Concept { get; set; }

        public List<DisplayTasks> Tasks { get; set; } 

        public User ConceptOwner { get; set; }
    }

    public class DisplayTasks
    {
        public TaskObj Task { get; set; }

        public List<Content> Contents { get; set; }
    }
}
