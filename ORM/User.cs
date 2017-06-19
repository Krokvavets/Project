using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class User
    {
        public User()
        {
            List< Message > Messages = new List<Message>();
            List<PrivateMessage> PrivateMessages = new List<PrivateMessage>();
            List<Role> Roles = new List<Role>();
        }

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public string AboutMe { get; set; }
        public DateTime CreationDate { get; set; }
        public int NumberOfPosts { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessages { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
