using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using PagedList;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentClient dc;

        public DepartmentController()
        {
            dc = new DepartmentClient();
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
	}
}