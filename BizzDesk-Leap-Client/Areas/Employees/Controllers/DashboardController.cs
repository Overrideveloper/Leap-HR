using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using BizzDesk_Leap_Client.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Areas.Employees.Controllers
{
    public class DashboardController : BaseController
    {
        EmployeeClient ec;
        EmployeeViewModel evm;
        public DashboardController()
        {
            ec = new EmployeeClient();
            evm = new EmployeeViewModel();
        }

        //
        // GET: /Employee/Dashboard/
        public ActionResult Index()
        {
            var id = Convert.ToString(Session["UserID"]);
            evm.Employee = ec.findAll().Where(s => s.EmployeeID == id).SingleOrDefault();
            return View("Index", evm);
        }
	}
}