using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class TaskObj
    {
        public TaskObj() { }

        public TaskObj(TaskObj t)
        {
            Id = t.Id;
            Name = t.Name;
            Description = t.Description;
            Crated = t.Crated;
                            //TODO Carted -> Created
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Crated { get; set; }
    }

    public class TaskVisual
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
