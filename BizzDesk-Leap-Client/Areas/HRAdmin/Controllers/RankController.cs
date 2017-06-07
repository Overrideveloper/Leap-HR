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
                ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title", rvm.Rank.DepartmentID);
                rc.Create(rvm.Rank);
                return Json(new { success = true });
            }
            return PartialView("Create", rvm);
        }
	}
}