using BizzDesk_Leap_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BizzDesk_Leap_API.DAL;

namespace BizzDesk_Leap_API.Controllers
{
    public class StaffLoginController : ApiController
    {

        private LeapDB db;
        public StaffLoginController()
        {
            db = new LeapDB();       
        }

        // POST api/Employee
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostStaffLogin(Employee employee)
        {
            var usr = db.Employee.Where(s => s.EmployeeID == employee.EmployeeID).SingleOrDefault();
            if (usr != null)
            {
                return Ok(usr);
            }
            return Ok(employee);
        }
    }
}
