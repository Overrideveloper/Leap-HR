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

        public RankController()
        {
            rc = new RankClient();
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
            //DepartmentViewModel dept = new DepartmentViewModel();
            
            var rank = new RankViewModel();
            //ViewBag.Department = new SelectList(dept.DepartmentList., "ID", "Title");
            return PartialView("Create", rank);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RankViewModel rvm)
        {
            DepartmentViewModel dept = new DepartmentViewModel();

            if (ModelState.IsValid)
            {
                rc.Create(rvm.Rank);
                return Json(new { success = true });
            }

            //ViewBag.DepartmentID = new SelectList(dept.DepartmentList, "ID", "Title", rvm.Rank.DepartmentID);
            return PartialView("Create", rvm);
        }
	}
}