﻿using System;
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
        public int EmployeeID { get; set; }


    }
}