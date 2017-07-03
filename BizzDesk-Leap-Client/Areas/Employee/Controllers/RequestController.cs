using BizzDesk_Leap_Client.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BizzDesk_Leap_Client.Areas.Employee.ViewModels;
using BizzDesk_Leap_Client.Controllers;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;

namespace BizzDesk_Leap_Client.Areas.Employee.Controllers
{
    public class RequestController : BaseController
    {
        RequestClient rc;
        LeaveClient lc;

        public RequestController()
        {
            rc = new RequestClient();
            lc = new LeaveClient();
        }

        // GET: /Employee/Request/
        public ActionResult Index(int? page)
        {
            var id = Convert.ToInt32(Session["ID"]);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.RequestsList = rc.findAll().Where(s => s.EmployeeID == id).ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var rvm = new RequestViewModel();
            ViewBag.Leaves = new SelectList(lc.findAll(), "ID", "Title");
            return PartialView("Create", rvm);
        }

        [HttpPost]
        public ActionResult Create(RequestViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                rvm.Request.EmployeeID = Convert.ToInt32(Session["ID"]);
                rvm.Request.RequestDate = DateTime.Now;
                rvm.Request.Status = Enums.Status.Pending;
                rc.Create(rvm.Request);
                return Json(new { success = true });
            }

            ViewBag.Leaves = new SelectList(lc.findAll(), "ID", "Title", rvm.Request.LeaveID);
            return PartialView("Create", rvm);
        }
	}
}