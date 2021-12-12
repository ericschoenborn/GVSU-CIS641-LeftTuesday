using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class TaskContent
    {
        public TaskContent() { }

        public TaskContent(TaskContent t)
        {
            Id = t.Id;
            Task = t.Task;
            Content = t.Content;
        }

        public int Id { get; set; }

        public int Task { get; set; }

        public int Content { get; set; }
    }
}
