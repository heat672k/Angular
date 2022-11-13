using System;
using worker_mngmt.Models;

namespace worker_mngmt.DTOs
{
    public class ProfileApplicationDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Category { get; set; }

        public int Likes { get; set; }

        public CandidateStatus Status { get; set; }

        public string OrgName { get; set; }
    }
}
