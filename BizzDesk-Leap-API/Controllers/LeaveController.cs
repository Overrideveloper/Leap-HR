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
    [RoutePrefix("api/leave")]
    public class LeaveController : ApiController
    {
        private LeapDB db = new LeapDB();

        // GET api/Leave
        [Route("readall")]
        public IQueryable<Leave> GetLeave()
        {
            return db.Leave;
        }

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

        [HttpGet]
        [Route("search/{searchString}")]
        public HttpResponseMessage SearchLeave(string searchString)
        {
            try
            {
                var httpResponseMessage = new HttpResponseMessage();
                httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(db.Leave.Where(p => p.Title.ToLower().Contains(searchString.ToLower())).ToList()));
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return httpResponseMessage;
            }
            catch
            {

                return null;
            }

        }

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