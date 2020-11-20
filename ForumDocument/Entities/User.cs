using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Entities
{
    public class User
    {
        /// <summary>
        /// id người dùng
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// tên người dùng
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// quyền hạn
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// số điểm
        /// </summary>
        public int Point { get; set; }
    }
}
