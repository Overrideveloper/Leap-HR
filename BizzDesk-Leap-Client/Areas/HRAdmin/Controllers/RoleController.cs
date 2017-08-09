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
    public class RoleController : Controller
    {
        RoleClient roc;
        DepartmentClient dc;
        RankClient rkc;
        EmployeeClient ec;
        LeaveClient lc;
        RequestClient rec;

        public RoleController()
        {
            roc = new RoleClient(); 
            
            dc = new DepartmentClient();
            rkc = new RankClient();
            ec = new EmployeeClient();
            lc = new LeaveClient();
            rec = new RequestClient();

            ViewBag.DepartmentCount = dc.findAll().ToArray().Length;
            ViewBag.RankCount = rkc.findAll().ToArray().Length;
            ViewBag.EmployeeCount = ec.findAll().ToArray().Length;
            ViewBag.LeaveCount = lc.findAll().ToArray().Length;
            ViewBag.RoleCount = roc.findAll().ToArray().Length;
            ViewBag.RequestCount = rec.findAll().Where(s => s.Status == Status.Pending && s.EndDate > DateTime.Now).ToArray().Length;
        }

        //
        // GET: /HRAdmin/Role/
        public ActionResult Index()
        {
            ViewBag.Roles = roc.findAll();
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoleViewModel rovm = new RoleViewModel();
            rovm.Role = roc.find(id);
            return PartialView("Edit", rovm);
        }

        [HttpPost]
        public ActionResult Edit(RoleViewModel rovm)
        {
            if (ModelState.IsValid)
            {
                roc.Edit(rovm.Role);
                return Json(new { success = true});
            }
            return PartialView("Edit", rovm);
        }

	}
}