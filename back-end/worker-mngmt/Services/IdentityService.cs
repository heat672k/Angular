using System;
using System.Linq;
using worker_mngmt.Data;
using worker_mngmt.DTOs;
using worker_mngmt.Models;

namespace worker_mngmt.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly AppDbContext _appDbContext;
        public IdentityService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public LogInReturnDto LogIn(LogInCreateDto user)
        {
            try
            {
                var loggedInUser = _appDbContext.Users.Single(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password));
                return new LogInReturnDto()
                {
                    Id = loggedInUser.Id,
                    Email = loggedInUser.Email,
                    Name = loggedInUser.Name,
                    UserType = UserType.User
                };
            }
            catch (Exception)
            {

            }

            try
            {
                var loggedInUser = _appDbContext.Orgs.Single(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password));
                return new LogInReturnDto()
                {
                    Id = loggedInUser.Id,
                    Email = loggedInUser.Email,
                    Name = loggedInUser.Name,
                    UserType = UserType.Org
                };
            }
            catch (Exception)
            {

            }

            return null;
        }

        public RegisterReturnDto RegisterUser(RegisterCreateDto dto)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password
            };

            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();

            return new RegisterReturnDto()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                UserType = UserType.User
            };
        }

        public RegisterReturnDto RegisterOrg(RegisterCreateDto dto)
        {
            Org org = new Org()
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                Name = dto.Name,
                Password = dto.Password
            };

            _appDbContext.Orgs.Add(org);
            _appDbContext.SaveChanges();

            return new RegisterReturnDto()
            {
                Id = org.Id,
                Email = org.Email,
                Name = org.Name,
                UserType = UserType.Org
            };
        }

        public GenericDataDto GetById(string id)
        {
            var user = _appDbContext.Users.FirstOrDefault(u => u.Id.Equals(new Guid(id)));
            if (user is not null) return new GenericDataDto()
            {
                Name = user.Name,
                Email = user.Email
            };

            var org = _appDbContext.Orgs.FirstOrDefault(u => u.Id.Equals(new Guid(id)));
            if (org is not null) return new GenericDataDto()
            {
                Name = org.Name,
                Email = org.Email
            };

            return null;
        }

        public void DeleteAccount(string id)
        {
            try
            {
                var user = _appDbContext.Users.SingleOrDefault(u => u.Id.Equals(new Guid(id)));
                _appDbContext.Candidates.RemoveRange(user.Candidates);
                _appDbContext.Users.Remove(user);
                _appDbContext.SaveChanges();
            }
            catch (Exception) { };

            try
            {
                var org = _appDbContext.Orgs.SingleOrDefault(o => o.Id.Equals(new Guid(id)));
                org.Offers.ToList().ForEach(o => _appDbContext.Reviews.RemoveRange(o.Reviews));
                _appDbContext.Offers.RemoveRange(org.Offers);
                _appDbContext.Orgs.Remove(org);
                _appDbContext.SaveChanges();
            }
            catch (Exception) { };
        }
    }
}
