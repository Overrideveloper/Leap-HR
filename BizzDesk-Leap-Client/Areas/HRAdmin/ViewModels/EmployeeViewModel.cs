using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels
{
    public class EmployeeViewModel
    {
        public BizzDesk_Leap_Client.Areas.HRAdmin.Models.Employee Employee
        {
            get;
            set;
        }

        public Gender Gender
        {
            get;
            set;
        }
    }
}