using System;
using System.Collections;
using System.Collections.Generic;

namespace worker_mngmt.Models
{
    public class User
    {
        public User()
        {
            Candidates = new List<Candidate>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        virtual public IEnumerable<Candidate> Candidates { get; set; }
    }
}
