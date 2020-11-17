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
    public class SACHController : ApiController
    {
        private taikhoan2Entities db = new taikhoan2Entities();

        // GET: api/SACH
        public IQueryable<SACH> GetSACHes()
        {
            return db.SACHes;
        }
        // GET: api/SACH/tensach
        [Route("api/SACH/gettensach/{tensach}")]
        public List<SACH> GetWithTenSach(string tenSach)
        {
            List<SACH> array = new List<SACH>();
            bool ok = false;
            foreach (SACH item in db.SACHes)
            {
                if (item.TENSACH.Equals(tenSach))
                {
                    ok = true;

                    array.Add(item);
                }
            }
            if (!ok)
                return null;
            else return array;
        }
        //GET:api/Saches
        public List<SACH> GetWithNXB(string nxb)
        {
            List<SACH> array = new List<SACH>();
            bool ok = false;
            foreach (SACH item in db.SACHes)
            {
                if (item.NHAXUATBAN.Equals(nxb))
                {
                    ok = true;

                    array.Add(item);
                }
            }
            if (!ok)
                return null;
            else return array;
        }

        //// GET: api/SACH/5
        //[ResponseType(typeof(SACH))]
        //public IHttpActionResult GetSACH(int id)
        //{
        //    SACH sACH = db.SACHes.Find(id);
        //    if (sACH == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(sACH);
        //}
        // GET: api/SACH/tentg
        //[ResponseType(typeof(SACH))]
        public List<SACH> Gettentacgia(string id)
        {
            List<SACH> array = new List<SACH>();
            bool ok = false;
            foreach (SACH item in db.SACHes)
            {
                if (item.TACGIA.Equals(id))
                {
                    ok = true;
                    array.Add(item);
                }
            }
            if (!ok)
                return null;
            else return array;
        }
        // GET: api/SACH/date
        //[ResponseType(typeof(SACH))]
        //[Route("sach/Datesach")]
        //public List<SACH> GetSACHGetSachWithDate()
        //{
        //    List<SACH> array = new List<SACH>();
        //    bool ok = false;
        //    int currentYear = int.Parse(DateTime.Now.Year.ToString());
        //    int time = currentYear - 5;

        //    foreach (SACH item in db.SACHes)
        //    {
        //        string[] spl = item.NAMXUATBAN.ToString().Split('-');
        //        if (int.Parse(spl[0]) >= time)
        //        {
        //            ok = true;
        //            array.Add(item);
        //        }
        //    }
        //    if (!ok)
        //        return null;

        //    else return array;
        //}


        // PUT: api/SACH/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSACH(int id, SACH sACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sACH.MASACH)
            {
                return BadRequest();
            }

            db.Entry(sACH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SACHExists(id))
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

        // POST: api/SACH
        [ResponseType(typeof(SACH))]
        public IHttpActionResult PostSACH(SACH sACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SACHes.Add(sACH);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SACHExists(sACH.MASACH))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sACH.MASACH }, sACH);
        }

        // DELETE: api/SACH/5
        [ResponseType(typeof(SACH))]
        public IHttpActionResult DeleteSACH(int id)
        {
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return NotFound();
            }

            db.SACHes.Remove(sACH);
            db.SaveChanges();

            return Ok(sACH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SACHExists(int id)
        {
            return db.SACHes.Count(e => e.MASACH == id) > 0;
        }
    }

}