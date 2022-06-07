using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class UserDto
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //public string Password { get; set; }

        //public string ConfirmPassword { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; } = new List<int>();
    }
}
