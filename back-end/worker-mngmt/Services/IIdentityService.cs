using Microsoft.AspNetCore.Mvc;
using worker_mngmt.DTOs;

namespace worker_mngmt.Services
{
    public interface IIdentityService
    {
        void DeleteAccount(string id);
        GenericDataDto GetById(string id);
        LogInReturnDto LogIn(LogInCreateDto worker);
        RegisterReturnDto RegisterOrg(RegisterCreateDto dto);
        RegisterReturnDto RegisterUser(RegisterCreateDto dto);
    }
}
