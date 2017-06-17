using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BizzDesk_Leap_API.Enums;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Models
{
    public partial class Leave
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