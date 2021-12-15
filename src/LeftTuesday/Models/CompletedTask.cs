using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class CompletedTask
    {
        public CompletedTask() { }

        public CompletedTask(CompletedTask t)
        {
            Id = t.Id;
            Session = t.Session;
            Participant = t.Participant;
            Task = t.Task;
            Created = t.Created;
        }

        public int Id { get; set; }

        public int Session { get; set; }

        public int Participant { get; set; }

        public int Task { get; set; }

        public DateTime Created { get; set; }
    }
}
