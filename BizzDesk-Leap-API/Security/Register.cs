using BizzDesk_Leap_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Security
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The passwords don't match")]
        public string  ConfirmPassword { get; set; }

        public int RoleID { get; set; }

        [Required]
        [Display(Name = "Role")]
        public virtual Role Role { get; set; }
    }
}