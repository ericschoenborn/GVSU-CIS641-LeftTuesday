using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeftTuesday.Models
{
    public class SessionParticipant
    {
        public SessionParticipant() { }

        public SessionParticipant(SessionParticipant t)
        {
            Id = t.Id;
            Session = t.Session;
            Participant = t.Participant;
        }

        public int Id { get; set; }

        public int Session { get; set; }

        public int Participant { get; set; }
    }
}
