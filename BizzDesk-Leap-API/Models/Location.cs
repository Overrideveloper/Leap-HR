using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BizzDesk_Leap_API.Models
{
    public partial class Location
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