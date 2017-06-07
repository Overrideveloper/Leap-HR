using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BizzDesk_Leap_Client.Areas.HRAdmin.Models;

namespace BizzDesk_Leap_Client.Areas.HRAdmin.Controllers
{
    public class RankController : Controller
    {
        RankClient rc;

        public RankController()
        {
            rc = new RankClient();
        }

        //
        // GET: /HRAdmin/Rank/
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.RankList = rc.findAll().ToPagedList(pageNumber, pageSize);
            return View();
        }
	}
}