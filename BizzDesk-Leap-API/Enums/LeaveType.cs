using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_API.Enums
{
    public enum LeaveType
    {
        [Display(Name = "Unpaid")]
        Unpaid = 0,

        [Display(Name = "Paid")]
        Paid = 1

    }
}