using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using BizzDesk_Leap_Client.Areas.Employees.Models;
using BizzDesk_Leap_Client.Areas.Employees.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class LeaveController : Controller
    {
        LeaveClient lc;
        DepartmentClient dc;
        RankClient rc;
        EmployeeClient ec;
        RoleClient roc;
        RequestClient rec;

        public LeaveController()
        {
            lc = new LeaveClient();
            dc = new DepartmentClient();
            rc = new RankClient();
            ec = new EmployeeClient();
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
        // GET: /HRAdmin/Leave/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.LeaveList = lc.findAll().ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var lvm = new LeaveViewModel();
            return PartialView("Create", lvm);
        }

        [HttpPost]
        public ActionResult Create(LeaveViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                lc.Create(lvm.Leave);
                return Json(new { success = true});
            }
            return PartialView("Create", lvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LeaveViewModel lvm = new LeaveViewModel();
            lvm.Leave = lc.find(id);
            return PartialView("Edit", lvm);
        }

        [HttpPost]
        public ActionResult Edit(LeaveViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                lc.Edit(lvm.Leave);
                return Json(new { success = true});
            }
            return PartialView("Edit", lvm);
        }

        public ActionResult Delete(int id)
        {
            lc.Delete(id);
            return RedirectToAction("Index");
        }
	}
}