using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Security
{
    public class SecurityController : Controller
    {
        RegisterClient reg;
        public SecurityController()
        {
            reg = new RegisterClient();
        }

        //
        // GET: /HRAdmin/Security/
        public ActionResult Index()
        {
            ViewBag.Users = reg.findAll();
            return View();
        }

        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return PartialView(model);
        }
	}
}