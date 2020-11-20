using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Entities
{
    public class Document
    {
        /// <summary>
        /// id tài liệu
        /// </summary>
        public int DocumentID { get; set; }
        /// <summary>
        /// tên tài liệu
        /// </summary>
        public string DocumentName { get; set; }
        /// <summary>
        /// ảnh đại diện của tài liệu
        /// </summary>
        public string ImageFeature { get; set; }
        /// <summary>
        /// link tài liệu
        /// </summary>
        public string DocumentLink { get; set; }
        /// <summary>
        /// dung lượng tài liệu
        /// </summary>
        public float DocumentSize { get; set; }
        /// <summary>
        /// đuôi file định dạng
        /// </summary>
        public string DocumentType { get; set; }
        /// <summary>
        /// số điểm
        /// </summary>
        public int Point { get; set; }
        /// <summary>
        /// số lượt xem
        /// </summary>
        public int ViewCount { get; set; }
        /// <summary>
        /// số lượt tải
        /// </summary>
        public int DownloadCount { get; set; }
        /// <summary>
        /// id người đăng
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// tên người đăng tài liệu
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// mô tả tài liệu
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// loại chuyên mục
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// số lượt bị report
        /// </summary>
        public int ReportCount { get; set; }
    }
}
