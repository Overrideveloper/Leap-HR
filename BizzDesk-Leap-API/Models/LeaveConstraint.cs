using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BizzDesk_Leap_API.Models
{
    public class LeaveConstraint
    {
        [DisplayName("Gender")]
        public string? GenderConstraint { get; set; }

        [DisplayName("Department")]
        public int? DepartmentID { get; set; }
        public virtual Department DepartmentConstraint { get; set; }

        [DisplayName("Rank")]
        public int? RankID { get; set; }
        public virtual Rank RankConstraint { get; set; }
    }
}