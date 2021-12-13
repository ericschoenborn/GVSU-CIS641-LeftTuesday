using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class Content
    {
        public Content() { }

        public Content(Content t)
        {
            Id = t.Id;
            Type = t.Type;
            Value = t.Value;
            Created = t.Created;
        }

        public int Id { get; set; }

        public int Type { get; set; }

        public string Value { get; set; }

        public DateTime Created { get; set; }
    }
}
