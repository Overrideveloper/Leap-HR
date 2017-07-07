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
    public class RoleController : Controller
    {
        RoleClient roc;

        public RoleController()
        {
            roc = new RoleClient();
        }

        //
        // GET: /HRAdmin/Role/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Roles = roc.findAll().ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var rovm = new RoleViewModel();
            return PartialView("Create", rovm);
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel rovm)
        {
            if (ModelState.IsValid)
            {
                roc.Create(rovm.Role);
                return Json(new { success = true});
            }
            return PartialView("Create", rovm);
        }
	}
}