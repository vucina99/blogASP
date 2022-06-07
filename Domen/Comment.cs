using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Comment : Entity
    {
        public string Text { get; set; }

        public int idPost { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
