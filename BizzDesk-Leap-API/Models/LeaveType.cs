using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Models
{
    public class LeaveType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }   

        [DisplayName("Gender")]
        public string GenderConstraint { get; set; }
    }
}