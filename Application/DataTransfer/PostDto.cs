using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Text { get; set; }

        public string CreatedAt { get; set; }

        //public bool isLiked { get; set; }


        //public IFormFile ImageFile { get; set; }


        public int SumLikes { get; set; }
        public int SumComments { get; set; }


        //public IEnumerable<int> IdHashTag { get; set; } = new List<int>();
        public IEnumerable<HashTagDto> PostHashTag { get; set; } = new List<HashTagDto>();

        //public IEnumerable<int> IdLike { get; set; } = new List<int>();
        //public IEnumerable<string> Like { get; set; } = new List<string>();

        public IEnumerable<CommentDto> Comments { get; set; } = new List<CommentDto>();


        public IEnumerable<UsersLikesDto> Likes { get; set; } = new List<UsersLikesDto>();
    }
}
