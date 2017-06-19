using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class ProfileViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 2)]
        [Display(Name = "Enter your first name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 2)]
        [Display(Name = "Enter your last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 2)]
        [Display(Name = "Enter your last nickname")]
        public string Nickname { get; set; }
        public byte[] Photo { get; set; }
        public string AboutMe { get; set; }
        public DateTime CreationDate { get; set; }
        public int NumberOfPosts { get; set; }
        public IEnumerable<RoleEntity> Roles { get; set; }
        public bool Administrator { get; set; }
        public bool Moderator { get; set; }
        public bool User { get; set; }
    }
}