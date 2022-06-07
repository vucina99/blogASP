using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PostsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Text { get; set; }

        public string CreatedAt { get; set; }


        public int SumLikes { get; set; }
        public int SumComments { get; set; }

    }
}
