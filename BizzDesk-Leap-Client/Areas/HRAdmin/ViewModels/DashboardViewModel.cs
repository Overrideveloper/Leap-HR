using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels
{
    public class DashboardViewModel
    {
        public DepartmentClient DepartmentClient
        {
            get;
            set;
        }

        public RankClient RankClient
        {
            get;
            set;
        }

        public EmployeeClient EmployeeClient
        {
            get;
            set;
        }

        public LeaveClient LeaveClient
        {
            get;
            set;
        }
    }
}