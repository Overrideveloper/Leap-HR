﻿using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Controllers
{
    public class StaffLoginController : Controller
    {
        EmployeeClient ec;
        public StaffLoginController()
        {
            ec = new EmployeeClient();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var evm = new EmployeeViewModel();
            return View("Login", evm);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(EmployeeViewModel evm)
        {
            var usr = ec.findAll().Where(s => s.EmployeeNumber == evm.Employee.EmployeeNumber).FirstOrDefault();

            if (usr != null)
            {
                Session["ID"] = Convert.ToInt32(usr.ID);
                Session["FName"] = usr.FirstName.ToString();
                Session["LName"] = usr.LastName.ToString();
                Session["UserID"] = usr.EmployeeNumber.ToString();
                return RedirectToAction("Index", "Dashboard", new { Area = "Employees" });
            }
            else
            {
                ModelState.AddModelError("Error", "Employee ID is incorrect");
            }

            return View("Login");
        }
	}
}