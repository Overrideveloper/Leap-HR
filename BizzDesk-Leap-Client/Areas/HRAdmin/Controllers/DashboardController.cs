using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.Employees.Models;
using BizzDesk_Leap_Client.Areas.Employees.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class DashboardController : Controller
    {
        DepartmentClient dc;
        RankClient rc;
        EmployeeClient ec;
        LeaveClient lc;
        RoleClient roc;
        RequestClient rec;

        public DashboardController()
        {
            dc = new DepartmentClient();
            rc = new RankClient();
            ec = new EmployeeClient();
            lc = new LeaveClient();
            roc = new RoleClient();
            rec = new RequestClient();
        }

        //
        // GET: /HRAdmin/Dashboard/
        public ActionResult Index()
        {
            ViewBag.DepartmentCount = dc.findAll().ToArray().Length;
            ViewBag.RankCount = rc.findAll().ToArray().Length;
            ViewBag.EmployeeCount = ec.findAll().ToArray().Length;
            ViewBag.LeaveCount = lc.findAll().ToArray().Length;
            ViewBag.RoleCount = roc.findAll().ToArray().Length;
            ViewBag.RequestCount = rec.findAll().Where(s => s.Status == Status.Pending && s.EndDate > DateTime.Now).ToArray().Length;
            return View();
        }
	}
}