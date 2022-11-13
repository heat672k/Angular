using System.Collections.Generic;
using System;
using worker_mngmt.Models;

namespace worker_mngmt.DTOs
{
    public class OfferDetailDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Category { get; set; }

        public int Likes { get; set; }

        virtual public Guid OrgId { get; set; }

        virtual public IEnumerable<Guid> CandidatesId { get; set; }
    }
}
