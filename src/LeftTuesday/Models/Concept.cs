﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class Concept
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class ConceptVisual
    {
        public List<User> Owners { get; set; }

        public List<User> Managers { get; set; }

        public List<User> Participants { get; set; }

        public List<Task> Tasks { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
