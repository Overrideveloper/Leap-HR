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
        public StaffLoginController()
        {
            slc = new StaffLoginClient();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(EmployeeViewModel evm)
        {
            slc.Login(evm.Employee);
            if (slc.Login(evm.Employee) == true)
            {
                /*Session["FName"] = evm.Employee.FirstName.ToString();
                Session["LName"] = evm.Employee.LastName.ToString();
                Session["ID"] = evm.Employee.EmployeeID.ToString();
                Session["Dept"] = evm.Employee.Department.Title.ToString();
                Session["Rank"] = evm.Employee.Rank.Title.ToString();*/
                return RedirectToAction("Index", "Dashboard", new { Area = "HRAdmin" });
            }
            else
            {
                ModelState.AddModelError("Error", "Employee ID is incorrect");
            }

            return View();
        }
	}
}