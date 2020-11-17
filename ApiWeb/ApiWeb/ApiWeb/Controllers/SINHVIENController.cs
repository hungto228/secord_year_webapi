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
    public class SINHVIENController : ApiController
    {
        private taikhoan2Entities db = new taikhoan2Entities();

        // GET: api/SINHVIEN
        public IQueryable<SINHVIEN> GetSINHVIENs()
        {
            return db.SINHVIENs;
        }

        // GET: api/SINHVIEN/5
        [ResponseType(typeof(SINHVIEN))]
        public IHttpActionResult GetSINHVIEN(int id)
        {
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return NotFound();
            }

            return Ok(sINHVIEN);
        }

        // PUT: api/SINHVIEN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSINHVIEN(int id, SINHVIEN sINHVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sINHVIEN.MASV)
            {
                return BadRequest();
            }

            db.Entry(sINHVIEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SINHVIENExists(id))
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

        // POST: api/SINHVIEN
        [ResponseType(typeof(SINHVIEN))]
        public IHttpActionResult PostSINHVIEN(SINHVIEN sINHVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SINHVIENs.Add(sINHVIEN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SINHVIENExists(sINHVIEN.MASV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sINHVIEN.MASV }, sINHVIEN);
        }

        // DELETE: api/SINHVIEN/5
        [ResponseType(typeof(SINHVIEN))]
        public IHttpActionResult DeleteSINHVIEN(int id)
        {
            SINHVIEN sINHVIEN = db.SINHVIENs.Find(id);
            if (sINHVIEN == null)
            {
                return NotFound();
            }

            db.SINHVIENs.Remove(sINHVIEN);
            db.SaveChanges();

            return Ok(sINHVIEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SINHVIENExists(int id)
        {
            return db.SINHVIENs.Count(e => e.MASV == id) > 0;
        }
    }
}