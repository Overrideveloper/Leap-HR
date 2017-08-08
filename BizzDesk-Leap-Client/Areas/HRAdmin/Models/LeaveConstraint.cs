using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class LeaveConstraint
    {

        [DisplayName("Gender")]
        public string GenderConstraint { get; set; }

        public int? DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department DepartmentConstraint { get; set; }

        public int? RankID { get; set; }

        [ForeignKey("RankID")]
        public virtual Rank RankConstraint { get; set; }
    }
}