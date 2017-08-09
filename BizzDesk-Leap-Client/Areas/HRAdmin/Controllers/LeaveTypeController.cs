using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class LeaveTypeController : Controller
    {
        LeaveTypeClient ltc;
        public LeaveTypeController()
        {
            ltc = new LeaveTypeClient();
        }

        //
        // GET: /HRAdmin/LeaveType/
        public ActionResult Index()
        {
            ViewBag.Types = ltc.findAll().OrderBy(s => s.Title); 
            return View();
        }

        //
        // GET: /HRAdmin/LeaveType/Create
        [HttpGet]
        public ActionResult Create()
        {
            var leavetype = new LeaveTypeViewModel();
            return PartialView("Create", leavetype);
        }

        //
        // POST: /HRAdmin/LeaveType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeViewModel leavetype)
        {
            if (ModelState.IsValid)
            {
                ltc.Create(leavetype.LeaveType);
                return Json(new { success = true });
            }

            return PartialView("Create", leavetype);
        }

        //
        // GET: /HRAdmin/LeaveType/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            LeaveTypeViewModel leavetype = new LeaveTypeViewModel();
            leavetype.LeaveType = ltc.find(id);
            return PartialView("Edit", leavetype);
        }

        //
        // POST: /HRAdmin/LeaveType/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel leavetype)
        {
            if (ModelState.IsValid)
            {
                ltc.Edit(leavetype.LeaveType);
                return Json(new { success = true });
            }
            return PartialView("Edit", leavetype);
        }

        //
        // POST: /HRAdmin/LeaveType/Delete/id
        public ActionResult Delete(int id)
        {
            ltc.Delete(id);
            return RedirectToAction("Index");
        }

	}
}