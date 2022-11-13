using System;
using worker_mngmt.Models;

namespace worker_mngmt.DTOs
{
    public class OfferApplicantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CandidateStatus Status { get; set; }
    }
}
