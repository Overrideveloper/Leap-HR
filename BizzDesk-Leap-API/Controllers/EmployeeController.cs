using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BizzDesk_Leap_API.Models;
using BizzDesk_Leap_API.DAL;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace BizzDesk_Leap_API.Controllers
{
    ///<Summary>
    ///API Controller for the employee model
    ///</Summary>
    [RoutePrefix("bma/api/employee")]
    public class EmployeeController : ApiController
    {
        private LeapDB db;

        public bool HexCheck(string check)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(check, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        ///<Summary>
        ///A constructor
        ///</Summary>
        public EmployeeController()
        {
            db = new LeapDB();
        }

        ///<Summary>
        ///Gets all employees
        ///</Summary>
        [Route("readall")]
        // GET api/Employee
        public IQueryable<Employee> GetEmployee()
        {
            return db.Employee.Include(p => p.Department).Include(p => p.Rank).Include(p => p.Location);
        }

        ///<Summary>
        ///Gets a particular employee using an id
        ///</Summary>
        // GET api/Employee/5
        [Route("read/{id:int?}")]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return BadRequest("Employee does not exist");
            }

            return Ok(employee);
        }

        ///<Summary>
        ///Gets an employee
        ///</Summary>
        // PUT api/Employee/user_id
        [Route("read_by_id/{user_id}")]
        public IHttpActionResult GetEmployeeByUserID(string user_id)
        {
            var employee = db.Employee.Where(s => s.user_id == user_id).Include(s => s.Department).Include(s => s.Rank).Include(s => s.Location);
            if (employee == null)
            {
                return BadRequest("No employee exists with this user id");
            }
            return Ok(employee);
        }

        ///<Summary>
        ///Edits an employee
        ///</Summary>
        // PUT api/Employee/5
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.ID)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        ///<Summary>
        ///Creates an employee
        ///</Summary>
        [Route("create", Name="CreatePost")]
        // POST api/Employee
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!HexCheck(employee.user_id))
            {
                return BadRequest("User id isn't valid");
            }

            db.Employee.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("CreatePost", new { id = employee.ID }, employee);
        }

        ///<Summary>
        ///Deletes an employee
        ///</Summary>
        // DELETE api/Employee/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        ///<Summary>
        ///Disposes unmanaged resources
        ///</Summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employee.Count(e => e.ID == id) > 0;
        }
    }
}