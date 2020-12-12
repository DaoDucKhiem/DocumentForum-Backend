using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Models
{
    public class PosterParam
    {
        public Guid Poster { get; set; }
        public Guid Downloader { get; set; }
        public int Point { get; set; }
        public int DocumentID { get; set; }
    }
}
