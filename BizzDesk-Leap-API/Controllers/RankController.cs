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
    [RoutePrefix("bma/api/rank")]
    public class RankController : ApiController
    {
        private LeapDB db;

        public RankController()
        {
            db = new LeapDB();
        }

        // GET api/Rank
        [Route("readall")]
        public IQueryable<Rank> GetRank()
        {
            return db.Rank.Include(r => r.Department);
        }

        [Route("readbyid/{id:int?}")]
        [ResponseType(typeof(Rank))]
        public IHttpActionResult GetRank(int id)
        {
            Rank rank = db.Rank.Find(id);
            if (rank == null)
            {
                return NotFound();
            }

            return Ok(rank);
        }

        [Route("readbydept/{id:int?}")]
        public IQueryable<Rank> GetRankByDept(int id) 
        {
            return db.Rank.Where(r => r.DepartmentID == id).Include(r => r.Department);
        }
        
        // PUT api/Rank/5
        public IHttpActionResult PutRank(int id, Rank rank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rank.ID)
            {
                return BadRequest();
            }

            db.Entry(rank).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankExists(id))
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

        // POST api/Rank
        [Route("create", Name="CreateRank")]
        [ResponseType(typeof(Rank))]
        public IHttpActionResult PostRank(Rank rank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rank.Add(rank);
            db.SaveChanges();

            return CreatedAtRoute("CreateRank", new { id = rank.ID }, rank);
        }

        // DELETE api/Rank/5
        [Route("delete/{id:int?}")]
        [ResponseType(typeof(Rank))]
        public IHttpActionResult DeleteRank(int id)
        {
            Rank rank = db.Rank.Find(id);
            if (rank == null)
            {
                return NotFound();
            }

            db.Rank.Remove(rank);
            db.SaveChanges();

            return Ok(rank);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RankExists(int id)
        {
            return db.Rank.Count(e => e.ID == id) > 0;
        }
    }
}