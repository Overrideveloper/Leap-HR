using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using PagedList;
using System.Net;
using BizzDesk_Leap_Client.Areas.Employees.Models;
using BizzDesk_Leap_Client.Areas.Employees.Enums;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeClient ec;
        DepartmentClient dc;
        RankClient rc;
        LeaveClient lc;
        RoleClient roc;
        RequestClient rec;
        LocationClient loc;

        public EmployeeController()
        {
            ec = new EmployeeClient();
            dc = new DepartmentClient();
            rc = new RankClient();
            lc = new LeaveClient();
            roc = new RoleClient();
            rec = new RequestClient();
            loc = new LocationClient();

            ViewBag.DepartmentCount = dc.findAll().ToArray().Length;
            ViewBag.RankCount = rc.findAll().ToArray().Length;
            ViewBag.EmployeeCount = ec.findAll().ToArray().Length;
            ViewBag.LeaveCount = lc.findAll().ToArray().Length;
            ViewBag.RoleCount = roc.findAll().ToArray().Length;
            ViewBag.RequestCount = rec.findAll().Where(s => s.Status == Status.Pending && s.EndDate > DateTime.Now).ToArray().Length;
        }
        //
        // GET: /HRAdmin/Employee/
        public ActionResult Index()
        {
            ViewBag.EmployeeList = ec.findAll().OrderBy(s => s.LastName);
            return View();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            var evm = new EmployeeViewModel();
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title");
            ViewBag.Rank = new SelectList(rc.findAll(), "ID", "Title");
            ViewBag.Location = new SelectList(loc.findAll(), "ID", "Title");
            return PartialView("Create", evm);
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel evm)
        {
            if (ModelState.IsValid)
            {
                if (ec.findAll().Any(s => s.EmployeeNumber == evm.Employee.EmployeeNumber))
                {
                    ModelState.AddModelError("UsedID", "This ID is already in use for an existing employee");
                }
                else
                {
                    ec.Create(evm.Employee);
                    return Json(new { success = true});
                }
            }
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title", evm.Employee.DepartmentID);
            ViewBag.Rank = new SelectList(rc.findAll(), "ID", "Title", evm.Employee.RankID);
            ViewBag.Location = new SelectList(loc.findAll(), "ID", "Title", evm.Employee.LocationID);
            return PartialView("Create", evm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.Employee = ec.find(id);
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title", evm.Employee.DepartmentID);
            ViewBag.Rank = new SelectList(rc.findAll(), "ID", "Title", evm.Employee.RankID);
            ViewBag.Location = new SelectList(loc.findAll(), "ID", "Title", evm.Employee.LocationID);
            return PartialView("Edit", evm);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel evm)
        {
            if (ModelState.IsValid)
            {
                ec.Edit(evm.Employee);
                return Json(new { success = true });
            }
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title", evm.Employee.DepartmentID);
            ViewBag.Rank = new SelectList(rc.findAll(), "ID", "Title", evm.Employee.RankID);
            ViewBag.Location = new SelectList(loc.findAll(), "ID", "Title", evm.Employee.LocationID);
            return PartialView("Edit", evm);
        }

        public ActionResult Delete(int id)
        {
            ec.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.Employee = ec.find(id);
            return PartialView("Details", evm);
        }
	}
}