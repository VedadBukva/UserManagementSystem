using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Helpers
{
    public class PaginationQueryDto
    {
        public string SortBy { get; set; }
        public string OrderBy { get; set; }
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}
