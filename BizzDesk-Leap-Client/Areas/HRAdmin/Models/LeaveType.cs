using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class LeaveType : LeaveConstraint
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
    }
}