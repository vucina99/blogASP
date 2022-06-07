using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Post : Entity
    {

        public string Title { get; set; }

        public string Image { get; set; }

        public string Text { get; set; }

        public virtual IEnumerable<PostHashTag> PostHashTags { get; set; } = new HashSet<PostHashTag>();
        public virtual IEnumerable<Like> Likes { get; set; } = new HashSet<Like>();
        public virtual IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
