using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class Location
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        public string LGA { get; set; }

        [Required]
        public string State { get; set; }
    }
}