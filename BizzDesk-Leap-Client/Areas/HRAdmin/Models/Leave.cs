using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BizzDesk_Leap_Client.Areas.HRAdmin.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class Leave
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Leave type is required")]
        public int? LeaveTypeID { get; set; }

        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType { get; set; }
    }
}