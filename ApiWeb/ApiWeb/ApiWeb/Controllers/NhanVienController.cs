using ApiWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiWeb.Controllers
{
    public class NhanVienController : ApiController
    {
        private taikhoan2Entities db = new taikhoan2Entities();
        // GET: api/NHANVIENs
        public IQueryable<NHANVIEN> GetNHANVIENs()
        {
            return db.NHANVIENs;
        }
     

        // GET: api/NHANVIENs/5
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult GetNHANVIENs(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            return Ok(nHANVIEN);
        }

        // PUT: api/NHANVIENs/5
        //[Route("api/NHANVIENs/{id}")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutNHANVIEN(string id, [FromBody] NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nHANVIEN.MaNV)
            {
                return BadRequest();
            }

            db.Entry(nHANVIEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NHANVIENExists(id))
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

        // POST: api/NHANVIENs
        //[Route("api/NHANVIENs")]
        [ResponseType(typeof(NHANVIEN))]
        [HttpPost]
        public IHttpActionResult PostNHANVIEN([FromBody] NHANVIEN nHANVIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NHANVIENs.Add(nHANVIEN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NHANVIENExists(nHANVIEN.MaNV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nHANVIEN.MaNV }, nHANVIEN);
        }

        // DELETE: api/NHANVIENs/5
        [ResponseType(typeof(NHANVIEN))]
        public IHttpActionResult DeleteNHANVIEN(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return NotFound();
            }

            db.NHANVIENs.Remove(nHANVIEN);
            db.SaveChanges();

            return Ok(nHANVIEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NHANVIENExists(string id)
        {
            return db.NHANVIENs.Count(e => e.MaNV == id) > 0;
        }
    }

}

