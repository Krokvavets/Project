using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Enter your e-mail")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email")]
        [Remote("ValidateEmail", "Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

        //[Required]
        //[Display(Name = "Enter the code from the image")]
        //public string Captcha { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

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
    }
}