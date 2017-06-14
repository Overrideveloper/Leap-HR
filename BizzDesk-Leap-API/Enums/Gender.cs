using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Enums
{
    public enum  Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female,
    }
}