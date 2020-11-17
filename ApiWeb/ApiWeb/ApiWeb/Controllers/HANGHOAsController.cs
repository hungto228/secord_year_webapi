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
using ApiWeb.Models;

namespace ApiWeb.Controllers
{
    public class HANGHOAsController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/HANGHOAs
        public IQueryable<HANGHOA> GetHANGHOAs()
        {
            return db.HANGHOAs;
        }

        // GET: api/HANGHOAs/5
        [ResponseType(typeof(HANGHOA))]
        public IHttpActionResult GetHANGHOA(string id)
        {
            HANGHOA hANGHOA = db.HANGHOAs.Find(id);
            if (hANGHOA == null)
            {
                return NotFound();
            }

            return Ok(hANGHOA);
        }

        // PUT: api/HANGHOAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHANGHOA(string id, HANGHOA hANGHOA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hANGHOA.MAHANG)
            {
                return BadRequest();
            }

            db.Entry(hANGHOA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HANGHOAExists(id))
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

        // POST: api/HANGHOAs
        [ResponseType(typeof(HANGHOA))]
        public IHttpActionResult PostHANGHOA(HANGHOA hANGHOA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HANGHOAs.Add(hANGHOA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HANGHOAExists(hANGHOA.MAHANG))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hANGHOA.MAHANG }, hANGHOA);
        }

        // DELETE: api/HANGHOAs/5
        [ResponseType(typeof(HANGHOA))]
        public IHttpActionResult DeleteHANGHOA(string id)
        {
            HANGHOA hANGHOA = db.HANGHOAs.Find(id);
            if (hANGHOA == null)
            {
                return NotFound();
            }

            db.HANGHOAs.Remove(hANGHOA);
            db.SaveChanges();

            return Ok(hANGHOA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HANGHOAExists(string id)
        {
            return db.HANGHOAs.Count(e => e.MAHANG == id) > 0;
        }
    }
}