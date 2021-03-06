﻿using System;
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
    public class LeaveController : Controller
    {
        LeaveClient lc;
        DepartmentClient dc;
        RankClient rc;
        EmployeeClient ec;
        RoleClient roc;
        RequestClient rec;
        LeaveTypeClient ltc;

        public LeaveController()
        {
            lc = new LeaveClient();
            dc = new DepartmentClient();
            rc = new RankClient();
            ec = new EmployeeClient();
            roc = new RoleClient();
            rec = new RequestClient();
            ltc = new LeaveTypeClient();

            ViewBag.DepartmentCount = dc.findAll().ToArray().Length;
            ViewBag.RankCount = rc.findAll().ToArray().Length;
            ViewBag.EmployeeCount = ec.findAll().ToArray().Length;
            ViewBag.LeaveCount = lc.findAll().ToArray().Length;
            ViewBag.RoleCount = roc.findAll().ToArray().Length;
            ViewBag.RequestCount = rec.findAll().Where(s => s.Status == Status.Pending && s.EndDate > DateTime.Now).ToArray().Length;
        }
        //
        // GET: /HRAdmin/Leave/
        public ActionResult Index()
        {
            ViewBag.LeaveList = lc.findAll().OrderBy(s => s.Title);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var lvm = new LeaveViewModel();
            ViewBag.Type = new SelectList(ltc.findAll(), "ID", "Title");
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
            ViewBag.Type = new SelectList(ltc.findAll(), "ID", "Title", lvm.Leave.LeaveTypeID);
            return PartialView("Create", lvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LeaveViewModel lvm = new LeaveViewModel();
            lvm.Leave = lc.find(id);
            ViewBag.Type = new SelectList(ltc.findAll(), "ID", "Title", lvm.Leave.LeaveTypeID);
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
            ViewBag.Type = new SelectList(ltc.findAll(), "ID", "Title", lvm.Leave.LeaveTypeID);
            return PartialView("Edit", lvm);
        }

        public ActionResult Delete(int id)
        {
            lc.Delete(id);
            return RedirectToAction("Index");
        }
	}
}