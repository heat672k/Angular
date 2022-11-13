using System.Collections.Generic;
using worker_mngmt.DTOs;

namespace worker_mngmt.Services
{
    public interface IUserService
    {
        IEnumerable<ProfileApplicationDto> GetApplications(string id);
    }
}