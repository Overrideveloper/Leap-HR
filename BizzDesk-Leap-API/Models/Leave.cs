using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BizzDesk_Leap_API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizzDesk_Leap_API.Models
{
    public partial class Leave
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public int? LeaveTypeID { get; set; }
        
        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType { get; set; }
    }
}