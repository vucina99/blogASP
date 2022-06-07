using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CreatePostDto
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public IFormFile ImageFile { get; set; }


        public IEnumerable<int> IdHashTag { get; set; } = new List<int>();

    }
}
