using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class RankController : Controller
    {
        RankClient rc;
        DepartmentClient dc;

        public RankController()
        {
            rc = new RankClient();
            dc = new DepartmentClient();
        }

        //
        // GET: /HRAdmin/Rank/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.RankList = rc.findAll().ToPagedList(pageNumber, pageSize);
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