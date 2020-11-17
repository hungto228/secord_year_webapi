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
    public class TaiKhoanController : ApiController
    {
        private taikhoan2Entities db = new taikhoan2Entities();

        // GET: api/TaiKhoans
        public IQueryable<TAIKHOAN> GetTaiKhoans()
        {
            return db.TAIKHOANs;
        }

        // GET: api/TaiKhoans/5
        [ResponseType(typeof(TAIKHOAN))]
        public IHttpActionResult GetTaiKhoan(string id)
        {
            TAIKHOAN taiKhoan = db.TAIKHOANs.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return Ok(taiKhoan);
        }

        // PUT: api/TaiKhoans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiKhoan(string id, TAIKHOAN taiKhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taiKhoan.TENTK)
            {
                return BadRequest();
            }

            db.Entry(taiKhoan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanExists(id))
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

        // POST: api/TaiKhoans
        [ResponseType(typeof(TAIKHOAN))]
        public IHttpActionResult PostTaiKhoan(TAIKHOAN taiKhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TAIKHOANs.Add(taiKhoan);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TaiKhoanExists(taiKhoan.TENTK))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = taiKhoan.TENTK }, taiKhoan);
        }

        // DELETE: api/TaiKhoans/5
        [ResponseType(typeof(TAIKHOAN))]
        public IHttpActionResult DeleteTaiKhoan(string id)
        {
            TAIKHOAN taiKhoan = db.TAIKHOANs.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            db.TAIKHOANs.Remove(taiKhoan);
            db.SaveChanges();

            return Ok(taiKhoan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaiKhoanExists(string id)
        {
            return db.TAIKHOANs.Count(e => e.TENTK == id) > 0;
        }
    }
}
