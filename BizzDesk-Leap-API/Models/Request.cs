using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BizzDesk_Leap_API.Models;
using BizzDesk_Leap_API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizzDesk_Leap_API.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public Status Status { get; set; }

        //Entity Relationships
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        public int LeaveID { get; set; }

        public virtual Leave Leave { get; set; }

    }
}