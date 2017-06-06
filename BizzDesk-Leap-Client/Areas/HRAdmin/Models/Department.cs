using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
    }
}