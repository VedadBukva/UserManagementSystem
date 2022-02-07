using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Helpers
{
    public class PaginationDto<T>
    {
        public IEnumerable<T> ModelList { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }

        public int TotalItems { get; set; }
    }
}
