using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Entities
{
    public class Report
    {
        /// <summary>
        /// id báo cáo
        /// </summary>
        public int ReportID { get; set; }
        /// <summary>
        /// id người báo cáo
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// tên người tạo
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// nội dung báo cáo
        /// </summary>
        public string ReportContent { get; set; }
        /// <summary>
        /// loại báo cáo
        /// </summary>
        public string ReportType { get; set; }
        /// <summary>
        /// Tên tài liệu
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// id tài liệu bị báo cáo
        /// </summary>
        public int DocumentID { get; set; }
        /// <summary>
        /// id comment bị báo cáo
        /// </summary>
        public int CommentID { get; set; }
        /// <summary>
        /// tên người bình luận
        /// </summary>
        public string UserComment { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public int Status { get; set; }


    }
}
