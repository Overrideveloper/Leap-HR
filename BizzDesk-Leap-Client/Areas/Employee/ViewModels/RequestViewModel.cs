using BizzDesk_Leap_Client.Areas.Employee.Enums;
using BizzDesk_Leap_Client.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizzDesk_Leap_Client.Areas.Employee.ViewModels
{
    public class RequestViewModel
    {
        public Request Request
        {
            get;
            set;
        }

        public Status Status
        {
            get;
            set;
        }
    }
}