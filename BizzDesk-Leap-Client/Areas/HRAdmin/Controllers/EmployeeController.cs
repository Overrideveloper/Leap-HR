using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using PagedList;
using System.Net;

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
        public ActionResult Create()
        {
            var evm = new EmployeeViewModel();
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title");
            ViewBag.Rank = new SelectList(rc.findAll(), "ID", "Title");
            return PartialView("Create", evm);
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel evm)
        {
            if (ModelState.IsValid)
            {
                if (ec.findAll().Any(s => s.EmployeeID == evm.Employee.EmployeeID))
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
            return PartialView("Create", evm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.Employee = ec.find(id);
            ViewBag.Department = new SelectList(dc.findAll(), "ID", "Title", evm.Employee.DepartmentID);
            ViewBag.Rank = new SelectList(rc.findAll(), "ID", "Title", evm.Employee.RankID);
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
            return PartialView("Edit", evm);
        }

        public ActionResult Delete(int id)
        {
            ec.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Details = ec.find(id);

            return PartialView("Details");
        }

	}
}