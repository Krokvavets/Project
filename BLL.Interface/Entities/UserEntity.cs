using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public string AboutMe { get; set; }
        public DateTime CreationDate { get; set; }
        public int NumberOfPosts { get; set; }
    }
}
