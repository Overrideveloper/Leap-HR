using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using BizzDesk_Leap_Client.Areas.HRAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class LocationController : Controller
    {
        LocationClient loc;
        public LocationController()
        {
            loc = new LocationClient();
        }

        //
        // GET: /HRAdmin/Location/
        public ActionResult Index()
        {
            ViewBag.Location = loc.findAll().OrderBy(s => s.Title);
            return View();
        }

        //
        // GET: /HRAdmin/Location/Create
        public ActionResult Create() {
            var lovm = new LocationViewModel();
            return PartialView("Create", lovm);
        }

        //
        // POST: /HRAdmin/Location/Create
        [HttpPost]
        public ActionResult Create(LocationViewModel lovm)
        {
            if(ModelState.IsValid)
            {
                loc.Create(lovm.Location);
                return Json(new { success = true });
            }

            return PartialView("Create", lovm);
        }

        //
        // GET: /HRAdmin/Location/Edit/id
        public ActionResult Edit(int id) 
        {
            LocationViewModel lovm = new LocationViewModel();
            lovm.Location = loc.find(id);

            if (lovm.Location == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", lovm);
        }

        //
        // POST: /HRAdmin/Location/Edit/id
        public ActionResult Edit(LocationViewModel lovm) 
        {
            if (ModelState.IsValid)
            {
                loc.Edit(lovm.Location);
                return Json(new { success = true });
            }
            return PartialView("Edit", lovm);
        }

        //
        // POST: /HRAdmin/Location/Delete/id
        public ActionResult Delete(int id) 
        {
            loc.Delete(id);
            return RedirectToAction("Index");
        }
	}
}