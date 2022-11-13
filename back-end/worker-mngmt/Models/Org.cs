using System;
using System.Collections.Generic;

namespace worker_mngmt.Models
{
    public class Org
    {
        public Org()
        {
            Offers = new List<Offer>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        virtual public IEnumerable<Offer> Offers{ get; set; }
    }
}
