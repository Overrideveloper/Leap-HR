using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Areas.Employee.Controllers
{
    public class DashboardController : BaseController
    {
        EmployeeClient ec;
        public DashboardController()
        {
            ec = new EmployeeClient();
        }

        //
        // GET: /Employee/Dashboard/
        public ActionResult Index()
        {
            var id = Convert.ToString(Session["UserID"]);
            ViewBag.EmployeeDetails = ec.findAll().Where(s => s.EmployeeID == id).SingleOrDefault();
            return View();
        }
	}
}