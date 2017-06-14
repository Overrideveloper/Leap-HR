using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BizzDesk_Leap_Client.Areas.HRAdmin.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Employee ID is required")]
        public int ID { get; set; }

        [Required]
        [StringLength(12)]
        public string EmployeeID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Select a gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Date of Appointment is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        //Entity relationships

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Rank is required")]
        public int RankID { get; set; }

        public virtual Rank Rank { get; set; }
    }
}