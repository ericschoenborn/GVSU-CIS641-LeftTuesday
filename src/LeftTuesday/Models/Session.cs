using System;

namespace LeftTuesday.Models
{
    public class Session
    {
        public Session(){ }

        public Session(Session t)
        {
            Id = t.Id;
            Name = t.Name;
            Concept = t.Concept;
            Description = t.Description;
            Start = t.Start;
            End = t.End;
            Created = Created;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Concept { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DateTime Created { get; set; }
    }
}
