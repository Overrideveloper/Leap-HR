using BizzDesk_Leap_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BizzDesk_Leap_API.DAL;
using System.Threading.Tasks;


namespace BizzDesk_Leap_API.Controllers
{
    [RoutePrefix("api")]
    public class StaffLoginController : ApiController
    {

        private LeapDB db;
        public StaffLoginController()
        {
            db = new LeapDB();       
        }

        [HttpPost]
        [Route("stafflogin/{employee}")]
        public IHttpActionResult PostStaffLogin(string EmployeeID)
        {
            var usr = db.Employee.Where(s => s.EmployeeID == EmployeeID).SingleOrDefault();
            if (usr == null)
            {
                return BadRequest(); 
            }
            return Ok(usr);
        }
    }
}
