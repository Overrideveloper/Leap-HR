using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BizzDesk_Leap_Client.Areas.HRAdmin.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Leave Title is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Leave Type is Required")]
        public LeaveType LeaveType { get; set; }
    }
}