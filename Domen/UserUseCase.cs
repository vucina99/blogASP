using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class UserUseCase : Entity
    {
        public int IdUser { get; set; }
        public int IdUseCase { get; set; }

        public virtual User User { get; set; }
    }
}
