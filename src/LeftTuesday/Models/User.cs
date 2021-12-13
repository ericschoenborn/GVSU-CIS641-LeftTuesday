using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class User
    {
        public User(){}

        public User(User t)
        {
            Id = t.Id;
            Name = t.Name;
            Secret = t.Secret;
            Created = t.Created;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Secret { get; set; }

        public DateTime Created { get; set; }
    }
}
