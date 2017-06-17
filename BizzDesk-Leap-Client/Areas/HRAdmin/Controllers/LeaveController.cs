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
    public class LeaveController : Controller
    {
        LeaveClient lc;
        public LeaveController()
        {
            lc = new LeaveClient();
        }

        //
        // GET: /HRAdmin/Leave/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.LeaveList = lc.findAll().ToPagedList(pageNumber, pageSize);
            return View();
        }
	}
}