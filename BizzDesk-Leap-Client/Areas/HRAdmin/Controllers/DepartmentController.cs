using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using PagedList;
using BizzDesk_Leap_Client.Areas.Employees.Models;
using BizzDesk_Leap_Client.Areas.Employees.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentClient dc;
        RankClient rc;
        EmployeeClient ec;
        LeaveClient lc;
        RoleClient roc;
        RequestClient rec;

        public DepartmentController()
        {
            dc = new DepartmentClient();
            rc = new RankClient();
            ec = new EmployeeClient();
            lc = new LeaveClient();
            roc = new RoleClient();
            rec = new RequestClient();

            ViewBag.DepartmentCount = dc.findAll().ToArray().Length;
            ViewBag.RankCount = rc.findAll().ToArray().Length;
            ViewBag.EmployeeCount = ec.findAll().ToArray().Length;
            ViewBag.LeaveCount = lc.findAll().ToArray().Length;
            ViewBag.RoleCount = roc.findAll().ToArray().Length;
            ViewBag.RequestCount = rec.findAll().Where(s => s.Status == Status.Pending && s.EndDate > DateTime.Now).ToArray().Length;
        }

        //
        // GET: /HRAdmin/Department/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.DepartmentList = dc.findAll().ToPagedList(pageNumber, pageSize);
            return View();

        }

        [HttpGet]
        public ActionResult Create()
        {
            var department = new DepartmentViewModel();
            return PartialView("Create", department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                dc.Create(dvm.Department);
                return Json(new { success = true });
            }

            return PartialView("Create", dvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DepartmentViewModel dvm = new DepartmentViewModel();
            dvm.Department = dc.find(id);
            return PartialView("Edit", dvm);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                dc.Edit(dvm.Department);
                return Json(new { success = true });
            }
            return PartialView("Edit", dvm);
        }

        public ActionResult Delete(int id)
        {
            dc.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View("Search", new DepartmentViewModel());
        }

        [HttpPost]
        public ActionResult Search(DepartmentViewModel dvm)
        {
            ViewBag.Result = dc.Search(dvm.Department.Title).Result;
            return View("Search");
        }
	}
}