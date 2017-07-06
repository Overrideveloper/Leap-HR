using BizzDesk_Leap_Client.Areas.Employees.Models;
using BizzDesk_Leap_Client.Areas.Employees.Enums;
using BizzDesk_Leap_Client.Areas.Employees.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class RequestController : Controller
    {
        RequestViewModel rvm;
        RequestClient rc;

        public RequestController()
        {
            rc = new RequestClient();
            rvm = new RequestViewModel();
        }

        //
        // GET: /HRAdmin/Request/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.count = rc.findAll().Where(s => s.Status == Status.Pending && s.EndDate > DateTime.Now).ToArray().Length;
            ViewBag.Requests = rc.findAll().ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            RequestViewModel rvm = new RequestViewModel();
            rvm.Request = rc.find(id);
            return PartialView("Details", rvm); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(RequestViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                rc.Edit(rvm.Request);
                return Json(new { success = true });
            }
            return PartialView("Details", rvm);
        }
	}
}