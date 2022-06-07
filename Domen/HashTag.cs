using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class HashTag : Entity
    {
        public string Name { get; set; }

        public virtual IEnumerable<PostHashTag> PostHashTags { get; set; } = new HashSet<PostHashTag>();
    }
}
