using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
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
        EmployeeClient ec;
        public StaffLoginController()
        {
            ec = new EmployeeClient();
            slc = new StaffLoginClient();
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
            var usr = ec.findAll().Where(s => s.EmployeeID == evm.Employee.EmployeeID).FirstOrDefault();

            if (usr != null)
            {
                Session["FName"] = usr.FirstName.ToString();
                Session["LName"] = usr.LastName.ToString();
                Session["UserID"] = usr.EmployeeID.ToString();
                Session["Dept"] = usr.Department.Title.ToString();
                Session["Rank"] = usr.Rank.Title.ToString();
                return RedirectToAction("Index", "Dashboard", new { Area = "HRAdmin" });
            }
            else
            {
                ModelState.AddModelError("Error", "Employee ID is incorrect");
            }

            return View("Login");
        }
	}
}