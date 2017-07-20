using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Security
{
    public class SecurityController : Controller
    {
        //
        // GET: /HRAdmin/Security/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }
	}
}