using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class SearchCommentDto : PagedSearch
    {
        public int IdPost { get; set; }
    }
}
