﻿using BizzDesk_Leap_Client.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BizzDesk_Leap_Client.Areas.Employee.ViewModels;
using BizzDesk_Leap_Client.Controllers;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BizzDesk_Leap_Client.Areas.Employee.Controllers
{
    public class RequestController : BaseController
    {
        LeaveClient lc;
        RequestViewModel rvm;

        public RequestController()
        {
            rc = new RequestClient();
            lc = new LeaveClient();
            rvm = new RequestViewModel();
        }

        // GET: /Employee/Request/
        public ActionResult Index(int? page)
        {
            var id = Convert.ToInt32(Session["ID"]);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Leaves = new SelectList(lc.findAll(), "ID", "Title");
            var rvm = new RequestViewModel();
            return PartialView("Create", rvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                rc.Create(rvm.Request);
                return Json(new { success = true });
            }
            ViewBag.Leaves = new SelectList(lc.findAll(), "ID", "Title", rvm.Request.LeaveID);
            return PartialView("Create", rvm);
        }
	}
}