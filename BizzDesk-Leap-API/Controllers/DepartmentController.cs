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

namespace BizzDesk_Leap_API.Controllers
{
    [RoutePrefix("api/department")]
    public class DepartmentController : ApiController
    {
        private LeapDB db;

        public DepartmentController()
        {
            db = new LeapDB();
        }

        // GET api/Department
        public IQueryable<Department> GetDepartment()
        {
            return db.Department;
        }

        [HttpGet]
        [Route("search/{searchString}")]
        public HttpResponseMessage SearchDepartment(string searchString)
        {
            try
            {
                var httpResponseMessage = new HttpResponseMessage();
                httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(db.Department.Where(p => p.Title.ToLower().Contains(searchString.ToLower())).ToList()));
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return httpResponseMessage;
            }
            catch
            {

                return null;
            }

        }

        [HttpGet]
        [Route("alldepartments")]
        public IEnumerable<Department> DepartmentList()
        {
            return db.DepartmentList();
        }

        // GET api/Department/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(int id)
        {
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT api/Department/5
        public IHttpActionResult PutDepartment(int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.ID)
            {
                return BadRequest();
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST api/Department
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Department.Add(department);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = department.ID }, department);
        }

        // DELETE api/Department/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(int id)
        {
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Department.Remove(department);
            db.SaveChanges();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(int id)
        {
            return db.Department.Count(e => e.ID == id) > 0;
        }
    }
}