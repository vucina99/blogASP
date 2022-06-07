using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Like
    {
        public int IdPost { get; set; }

        public int idUser { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
