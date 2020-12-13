using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Entities
{
    public class Comment
    {
        /// <summary>
        /// id comment
        /// </summary>
        public int CommentID { get; set; }
        /// <summary>
        /// id người comment
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// tên người comment
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// nội dung comment
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// id tài liệu
        /// </summary>
        public int DocumentID { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// số report đã được báo cáo
        /// </summary>
        public int ReportCount { get; set; }
    }
}
