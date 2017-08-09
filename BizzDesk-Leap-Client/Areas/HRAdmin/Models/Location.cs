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

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public string LGA { get; set; }

        public string State { get; set; }
    }
}