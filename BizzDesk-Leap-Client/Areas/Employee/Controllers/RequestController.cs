using BizzDesk_Leap_Client.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BizzDesk_Leap_Client.Areas.Employee.ViewModels;
using BizzDesk_Leap_Client.Controllers;

namespace BizzDesk_Leap_Client.Areas.Employee.Controllers
{
    public class RequestController : BaseController
    {
        RequestClient rc;
        RequestViewModel rvm;

        public RequestController()
        {
            rc = new RequestClient();
            rvm = new RequestViewModel();
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


	}
}