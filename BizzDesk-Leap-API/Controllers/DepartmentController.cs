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
    ///<Summary>
    ///API Controller for the department model
    ///</Summary>
    [RoutePrefix("bma/api/department")]
    public class DepartmentController : ApiController
    {
        private LeapDB db;

        ///<Summary>
        ///A constructor
        ///</Summary>
        public DepartmentController()
        {
            db = new LeapDB();
        }

        ///<Summary>
        ///Gets all departments
        ///</Summary>
        // GET api/Department
        [Route("readall")]
        public IQueryable<Department> GetDepartment()
        {
            return db.Department;
        }

        ///<Summary>
        ///Gets a particular department using an id
        ///</Summary>
        // GET api/Department/5
        [Route("readbyid/{id:int?}")]
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

        ///<Summary>
        ///Edits a department
        ///</Summary>
        // PUT api/Department/5
        [Route("edit/{id:int?}")]
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

        ///<Summary>
        ///Creates a department
        ///</Summary>
        // POST api/Department
        [Route("create", Name="CreateDepartment")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Department.Add(department);
            db.SaveChanges();

            return CreatedAtRoute("CreateDepartment", new { id = department.ID }, department);
        }

        ///<Summary>
        ///Deletes a department
        ///</Summary>
        // DELETE api/Department/5
        [Route("delete/{id:int?}")]
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

        private bool DepartmentExists(int id)
        {
            return db.Department.Count(e => e.ID == id) > 0;
        }
    }
}