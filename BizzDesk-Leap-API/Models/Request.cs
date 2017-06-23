using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BizzDesk_Leap_API.Models;

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

        //Entity Relationships

        [Required]
        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public int LeaveID { get; set; }

        public virtual Leave Leave { get; set; }

    }
}