using BizzDesk_Leap_Client.Areas.HRAdmin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Security
{
    public class SecurityController : Controller
    {
        RoleClient role;
        public SecurityController()
        {
            role = new RoleClient();
        }
        //
        // GET: /HRAdmin/Security/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            ViewBag.Role = new SelectList(role.findAll(), "ID", "Title");
            Debug.WriteLine(ViewBag.Role);
            return View(model);
        }
	}
}