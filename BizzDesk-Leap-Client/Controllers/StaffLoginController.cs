﻿using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using BizzDesk_Leap_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Controllers
{
    public class StaffLoginController : Controller
    {
        StaffLoginClient slc;
        public StaffLoginController()
        {
            slc = new StaffLoginClient();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(EmployeeViewModel evm)
        {
            slc.Login(evm.Employee);
            if (slc.Login(evm.Employee) != null)
            {
                Session["FName"] = evm.Employee.FirstName.ToString();
                Session["LName"] = evm.Employee.LastName.ToString();
                Session["ID"] = evm.Employee.EmployeeID.ToString();
                Session["Dept"] = evm.Employee.Department.Title.ToString();
                Session["Rank"] = evm.Employee.Rank.Title.ToString();
            }

        }
	}
}