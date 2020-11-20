using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Models
{
    public class UserRegister
    {
        public Guid id { get; set; }
        public string name { get; set; }

        public string userName { get; set; }
        public string email { get; set; }
        public string listRoles { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string active { get; set; }
    }
}
