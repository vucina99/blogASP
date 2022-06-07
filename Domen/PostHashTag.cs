using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class PostHashTag
    {
        public int IdPost { get; set; }

        public int IdHashtag { get; set; }


        public virtual Post Post { get; set; }
        public virtual HashTag HashTag { get; set; }
    }
}
