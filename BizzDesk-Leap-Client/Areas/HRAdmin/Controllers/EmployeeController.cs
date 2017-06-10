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
    public class EmployeeController : Controller
    {
        EmployeeClient ec;
        DepartmentClient dc;
        RankClient rc;

        public EmployeeController()
        {
            ec = new EmployeeClient();
            dc = new DepartmentClient();
            rc = new RankClient();
        }
        //
        // GET: /HRAdmin/Employee/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.EmployeeList = ec.findAll().ToPagedList(pageNumber, pageSize);
            return View();
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var emp = new EmployeeViewModel();
            var dept = rc.findByDept(id);
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title");
            ViewBag.Rank = new SelectList(rc.find(id), "ID", "Title");
        }
	}
}