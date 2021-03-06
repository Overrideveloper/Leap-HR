﻿using System;
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
    [RoutePrefix("bma/api/request")]
    public class RequestController : ApiController
    {
        private LeapDB db = new LeapDB();

        // GET api/Request
        [Route("readall")]
        public IQueryable<Request> GetRequest()
        {
            return db.Request.Include(s => s.Employee).Include(s => s.Employee.Department).Include(s => s.Employee.Rank).Include(s => s.Employee.Location)
                .Include(s => s.Leave).Include(s => s.Leave.LeaveType);
        }

        // GET api/Request/5
        [ResponseType(typeof(Request))]
        public IHttpActionResult GetRequest(int id)
        {
            Request request = db.Request.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT api/Request/5
        public IHttpActionResult PutRequest(int id, Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.ID)
            {
                return BadRequest();
            }

            db.Entry(request).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST api/Request
        [Route("create")]
        [ResponseType(typeof(Request))]
        public IHttpActionResult PostRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Request.Add(request);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = request.ID }, request);
        }

        // DELETE api/Request/5
        [ResponseType(typeof(Request))]
        public IHttpActionResult DeleteRequest(int id)
        {
            Request request = db.Request.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            db.Request.Remove(request);
            db.SaveChanges();

            return Ok(request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestExists(int id)
        {
            return db.Request.Count(e => e.ID == id) > 0;
        }
    }
}