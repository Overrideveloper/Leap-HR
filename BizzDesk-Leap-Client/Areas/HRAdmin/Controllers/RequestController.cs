using BizzDesk_Leap_Client.Areas.Employees.Models;
using BizzDesk_Leap_Client.Areas.Employees.Enums;
using BizzDesk_Leap_Client.Areas.Employees.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class RequestController : Controller
    {
        RequestViewModel rvm;
        RequestClient rc;
        DepartmentClient dc;
        RankClient rkc;
        EmployeeClient ec;
        LeaveClient lc;
        RoleClient roc;

        public RequestController()
        {
            rc = new RequestClient();
            rvm = new RequestViewModel();

            dc = new DepartmentClient();
            rkc = new RankClient();
            ec = new EmployeeClient();
            lc = new LeaveClient();
            roc = new RoleClient();

            ViewBag.DepartmentCount = dc.findAll().ToArray().Length;
            ViewBag.RankCount = rkc.findAll().ToArray().Length;
            ViewBag.EmployeeCount = ec.findAll().ToArray().Length;
            ViewBag.LeaveCount = lc.findAll().ToArray().Length;
            ViewBag.RoleCount = roc.findAll().ToArray().Length;
        }

        //
        // GET: /HRAdmin/Request/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            Session["count"] = rc.findAll().Where(s => s.Status == Status.Pending && s.EndDate > DateTime.Now).ToArray().Length;
            ViewBag.Requests = rc.findAll().OrderByDescending(s => s.RequestDate).ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            RequestViewModel rvm = new RequestViewModel();
            rvm.Request = rc.find(id);
            return PartialView("Details", rvm); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(RequestViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                rc.Edit(rvm.Request);
                return Json(new { success = true });
            }
            return PartialView("Details", rvm);
        }
	}
}