using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels
{
    public class LeaveViewModel
    {
        public Leave Leave
        {
            get;
            set;
        }

        public LeaveType LeaveType
        {
            get;
            set;
        }
    }
}