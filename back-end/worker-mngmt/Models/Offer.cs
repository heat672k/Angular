using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace worker_mngmt.Models
{
    public class Offer
    {
        public Offer()
        {
            Candidates = new List<Candidate>();
            Reviews = new List<Review>();
        }

        public Guid Id { get; set; }

        public string Ttile { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Category { get; set; }

        virtual public Org Publisher { get; set; }

        virtual public IEnumerable<Candidate> Candidates { get; set; }

        virtual public IEnumerable<Review> Reviews { get; set; }
    }
}
