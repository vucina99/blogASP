using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CommentDto
    {
        //prikaz kod posta
        public int Id { get; set; }
        public int idUser { get; set; }
        //public int idPost { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        //public bool isAuthor { get; set; }

        //public string PostTitle { get; set; }
    }
}
