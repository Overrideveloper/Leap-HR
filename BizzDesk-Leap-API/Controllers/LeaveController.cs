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
    /// <summary>
    /// API controller for the Leave model
    /// </summary>
    [RoutePrefix("api/leave")]
    public class LeaveController : ApiController
    {
        private LeapDB db;

        /// <summary>
        /// A constructor
        /// </summary>
        public LeaveController()
        {
            db = new LeapDB();
        }

        /// <summary>
        /// Gets all leaves
        /// </summary>
        // GET api/Leave
        [Route("readall")]
        public IQueryable<Leave> GetLeave()
        {
            return db.Leave.Include(s => s.LeaveType).Include(s => s.LeaveType.DepartmentConstraint).Include(s => s.LeaveType.RankConstraint);
        }

        /// <summary>
        /// Gets a particular leave using an id
        /// </summary>
        // GET api/Leave/5
        [ResponseType(typeof(Leave))]
        public IHttpActionResult GetLeave(int id)
        {
            Leave leave = db.Leave.Find(id);
            if (leave == null)
            {
                return NotFound();
            }

            return Ok(leave);
        }

        /// <summary>
        /// Edits a leave
        /// </summary>
        // PUT api/Leave/5
        public IHttpActionResult PutLeave(int id, Leave leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leave.ID)
            {
                return BadRequest();
            }

            db.Entry(leave).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveExists(id))
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

        /// <summary>
        /// Creates a leave
        /// </summary>
        // POST api/Leave
        [Route("create")]
        [ResponseType(typeof(Leave))]
        public IHttpActionResult PostLeave(Leave leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leave.Add(leave);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = leave.ID }, leave);
        }

        /// <summary>
        /// Deletes a leave
        /// </summary>
        // DELETE api/Leave/5
        [ResponseType(typeof(Leave))]
        public IHttpActionResult DeleteLeave(int id)
        {
            Leave leave = db.Leave.Find(id);
            if (leave == null)
            {
                return NotFound();
            }

            db.Leave.Remove(leave);
            db.SaveChanges();

            return Ok(leave);
        }

        /// <summary>
        /// Disposes unmanaged resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaveExists(int id)
        {
            return db.Leave.Count(e => e.ID == id) > 0;
        }
    }
}