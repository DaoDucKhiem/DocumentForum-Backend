using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Models
{
    public class UserLoginInfo
    {
        [Key]
        public Guid UserID { get; set; }
        public string Token { get; set; }
        public string StringeeToken { get; set; }
    }
}
