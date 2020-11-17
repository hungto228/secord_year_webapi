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
    public class GIABANsController : ApiController
    {
        private QLBANHANGEntities db = new QLBANHANGEntities();

        // GET: api/GIABANs
        public IQueryable<GIABAN> GetGIABANs()
        {
            return db.GIABANs;
        }

        // GET: api/GIABANs/5
        [ResponseType(typeof(GIABAN))]
        public IHttpActionResult GetGIABAN(string id)
        {
            GIABAN gIABAN = db.GIABANs.Find(id);
            if (gIABAN == null)
            {
                return NotFound();
            }

            return Ok(gIABAN);
        }

        // PUT: api/GIABANs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGIABAN(string id, GIABAN gIABAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gIABAN.MAGIABAN)
            {
                return BadRequest();
            }

            db.Entry(gIABAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GIABANExists(id))
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

        // POST: api/GIABANs
        [ResponseType(typeof(GIABAN))]
        public IHttpActionResult PostGIABAN(GIABAN gIABAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GIABANs.Add(gIABAN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GIABANExists(gIABAN.MAGIABAN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gIABAN.MAGIABAN }, gIABAN);
        }

        // DELETE: api/GIABANs/5
        [ResponseType(typeof(GIABAN))]
        public IHttpActionResult DeleteGIABAN(string id)
        {
            GIABAN gIABAN = db.GIABANs.Find(id);
            if (gIABAN == null)
            {
                return NotFound();
            }

            db.GIABANs.Remove(gIABAN);
            db.SaveChanges();

            return Ok(gIABAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GIABANExists(string id)
        {
            return db.GIABANs.Count(e => e.MAGIABAN == id) > 0;
        }
    }
}