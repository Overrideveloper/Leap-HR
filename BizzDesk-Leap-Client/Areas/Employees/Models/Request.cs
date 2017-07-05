using BizzDesk_Leap_Client.Areas.Employees.Enums;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_Client.Areas.Employees.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Select start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Select end date")]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public Status Status { get; set; }

        //Entity Relationships

        [ForeignKey("Employee")]
        public int StaffID { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public int LeaveID { get; set; }

        public virtual Leave Leave { get; set; }
    }
}