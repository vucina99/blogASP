using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual IEnumerable<Like> Likes { get; set; } = new HashSet<Like>();
        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
    }
}
