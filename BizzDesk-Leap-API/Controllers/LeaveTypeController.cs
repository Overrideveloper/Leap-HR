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

namespace BizzDesk_Leap_API.Controllers
{
    [RoutePrefix("api/leavetype")]
    public class LeaveTypeController : ApiController
    {
        private LeapDB db = new LeapDB();

        // GET api/LeaveType
        [Route("readall")]
        public IQueryable<LeaveType> GetLeaveType()
        {
            return db.LeaveType;
        }

        // GET api/LeaveType/5
        [ResponseType(typeof(LeaveType))]
        public IHttpActionResult GetLeaveType(int id)
        {
            LeaveType leavetype = db.LeaveType.Find(id);
            if (leavetype == null)
            {
                return NotFound();
            }

            return Ok(leavetype);
        }

        // PUT api/LeaveType/5
        public IHttpActionResult PutLeaveType(int id, LeaveType leavetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leavetype.ID)
            {
                return BadRequest();
            }

            db.Entry(leavetype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveTypeExists(id))
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

        // POST api/LeaveType
        [Route("create")]
        [ResponseType(typeof(LeaveType))]
        public IHttpActionResult PostLeaveType(LeaveType leavetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeaveType.Add(leavetype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = leavetype.ID }, leavetype);
        }

        // DELETE api/LeaveType/5
        [ResponseType(typeof(LeaveType))]
        public IHttpActionResult DeleteLeaveType(int id)
        {
            LeaveType leavetype = db.LeaveType.Find(id);
            if (leavetype == null)
            {
                return NotFound();
            }

            db.LeaveType.Remove(leavetype);
            db.SaveChanges();

            return Ok(leavetype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaveTypeExists(int id)
        {
            return db.LeaveType.Count(e => e.ID == id) > 0;
        }
    }
}