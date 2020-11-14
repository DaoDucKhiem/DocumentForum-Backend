using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Models
{
    public class FilterParam
    {
        public string SearchKey { get; set; }
        public int CategoryID { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
