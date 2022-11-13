using System.Collections.Generic;
using System.Linq;
using worker_mngmt.Data;
using worker_mngmt.DTOs;

namespace worker_mngmt.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<ProfileApplicationDto> GetApplications(string id)
        {
            var candidatures = _appDbContext.Candidates
                .Where(c => c.User.Id.Equals(new System.Guid(id)))
                .Select(c => new ProfileApplicationDto()
                {
                    Id = c.Offer.Id,
                    OrgName = c.Offer.Publisher.Name,
                    Title = c.Offer.Ttile,
                    Description = c.Offer.Description,
                    Type = c.Offer.Type,
                    Category = c.Offer.Category,
                    Likes = c.Offer.Reviews.Count(),
                    Status = c.Status
                });

            return candidatures;
        }
    }
}
