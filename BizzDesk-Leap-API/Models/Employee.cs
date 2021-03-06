﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_API.Models
{
    public partial class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(24), MinLength(24)]
        public string user_id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(24), MinLength(5)]
        public string EmployeeNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; } 

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        //Entity relationships

        [Required]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        [Required]
        public int RankID { get; set; }
        public virtual Rank Rank { get; set; }
        
        public int? LocationID { get; set; }

        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }
    }
}