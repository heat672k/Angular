using System;

namespace worker_mngmt.Models
{
    public class Review
    {
        public Guid Id { get; set; }

        public virtual Offer Offer { get; set; }

        public virtual User Reviewer { get; set; }
    }
}
