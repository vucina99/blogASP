using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class SearchPostDto : PagedSearch
    {
        public IEnumerable<int> IdHashTag { get; set; } = new List<int>();


        public int? MinLike { get; set; }
        public int? MaxLike { get; set; }



        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
    }
}
