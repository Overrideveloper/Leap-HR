using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Models
{
    public partial class Department
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Department Title is required")]
        public string Title { get; set; }

        public virtual ICollection<Rank> Ranks { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}