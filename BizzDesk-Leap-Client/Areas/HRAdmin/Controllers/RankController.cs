using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using BizzDesk_Leap_Client.Areas.Employees.Models;
using BizzDesk_Leap_Client.Areas.Employees.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class RankController : Controller
    {
        RankClient rc;
        DepartmentClient dc;
        EmployeeClient ec;
        LeaveClient lc;
        RoleClient roc;
        RequestClient rec;

        public RankController()
        {
            rc = new RankClient();
            dc = new DepartmentClient();
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
        // GET: /HRAdmin/Rank/
        public ActionResult Index()
        {
            ViewBag.RankList = rc.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var rank = new RankViewModel();
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title");
            return PartialView("Create", rank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RankViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                rc.Create(rvm.Rank);
                return Json(new { success = true });
            }
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title", rvm.Rank.DepartmentID);
            return PartialView("Create", rvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RankViewModel rvm = new RankViewModel();
            rvm.Rank = rc.find(id);
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title", rvm.Rank.DepartmentID);
            return PartialView("Edit", rvm);
        }

        [HttpPost]
        public ActionResult Edit(RankViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                rc.Edit(rvm.Rank);
                return Json(new { success = true });
            }
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title", rvm.Rank.DepartmentID);
            return PartialView("Edit", rvm);
        }

        public ActionResult Delete(int id)
        {
            rc.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View("Search", new RankViewModel());
        }

        [HttpPost]
        public ActionResult Search(RankViewModel rvm)
        {
            ViewBag.Result = rc.Search(rvm.Rank.Title).Result;
            return View("Search");
        }
	}
}