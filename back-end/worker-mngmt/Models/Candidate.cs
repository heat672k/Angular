using System;

namespace worker_mngmt.Models
{
    public class Candidate
    {
        public Candidate()
        {
            Status = CandidateStatus.Pending;
        }

        public Guid Id { get; set; }

        public CandidateStatus Status { get; set; }

        virtual public User User { get; set; }

        virtual public Offer Offer { get; set; }
    }
}
