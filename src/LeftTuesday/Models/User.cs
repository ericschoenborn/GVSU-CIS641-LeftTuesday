using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public UserName Name { get; set; }
    }

    public class UserName
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
