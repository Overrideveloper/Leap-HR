using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BizzDesk_Leap_API.Enums;

namespace BizzDesk_Leap_API.Models
{
    public partial class Leave
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public LeaveType LeaveType { get; set; }
    }
}