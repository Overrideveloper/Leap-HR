using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
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
            return RedirectToAction("Index", "Dashboard", new { Area = "HRAdmin" });
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
	}
}