using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BizzDesk_Leap_Client.Areas.HRAdmin.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class Leave
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Select a type")]
        public LeaveType LeaveType { get; set; }
    }
}