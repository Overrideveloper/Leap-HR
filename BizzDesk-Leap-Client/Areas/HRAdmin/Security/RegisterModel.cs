using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Security
{
    public class RegisterModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }

        public virtual Role Role { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}