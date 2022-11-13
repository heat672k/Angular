using System;
using worker_mngmt.Models;

namespace worker_mngmt.DTOs
{
    public class RegisterReturnDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public UserType UserType { get; set; }

    }
}
