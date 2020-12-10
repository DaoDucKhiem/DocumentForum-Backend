using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Models
{
    public class PayloadInfo
    {
        public string user_name { get; set; }
        public Guid user_id { get; set; }
        public string email { get; set; }
        public string list_roles { get; set; } // ": "|SYS_ADMIN/Ứng dụng nhóm 12|",
    }
}
