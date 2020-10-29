using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Entities
{
    public class History
    {
        /// <summary>
        /// id lịch sử
        /// </summary>
        public int HistoryID { get; set; }
        /// <summary>
        /// id người báo cáo
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public string CreatedDate { get; set; }
    }
}
