using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Models
{
    public partial class Rank
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual Department Department { get; set; }
    }
}