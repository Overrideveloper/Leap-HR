using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public bool CanManageDepartments { get; set; }

        public bool CanManageRanks { get; set; }

        public bool CanManageEmployees { get; set; }

        public bool CanManageLeaves { get; set; }

        public bool CanManageRequests { get; set; }

        public bool CanManageRoles { get; set; }

        public bool CanManageUsers { get; set; }
    }
}