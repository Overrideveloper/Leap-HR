using BizzDesk_Leap_Client.Areas.Employees.Models;
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
            ViewBag.Requests = rc.findAll().ToPagedList(pageNumber, pageSize);
            return View();
        }
	}
}