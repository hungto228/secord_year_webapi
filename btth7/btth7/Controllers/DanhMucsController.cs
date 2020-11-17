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
using btth7.Models;

namespace btth7.Controllers
{
    public class DanhMucsController : ApiController
    {
        private btth7Entities1 db = new btth7Entities1();

        // GET: api/DanhMucs
        public IQueryable<DanhMuc> GetDanhMucs()
        {
            return db.DanhMucs;
        }
        // GET: api/DanhMucs/withtendm?tendm=dongho
        [HttpGet]
        public List<DanhMuc> withtendm(string tendm)
        {
            List<DanhMuc> listdm = new List<DanhMuc>();
            foreach (DanhMuc item in db.DanhMucs)
            {
                if (item.TenDanhMuc.Contains(tendm))
                {
                    listdm.Add(item);
                }
            }
            return listdm;
        }

        //// PUT: api/DanhMucs/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDanhMuc(string id, DanhMuc danhMuc)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != danhMuc.MaDanhMuc)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(danhMuc).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DanhMucExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

            //    return StatusCode(HttpStatusCode.NoContent);
            //}

            //// POST: api/DanhMucs
            //[ResponseType(typeof(DanhMuc))]
            //public IHttpActionResult PostDanhMuc(DanhMuc danhMuc)
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }

            //    db.DanhMucs.Add(danhMuc);

            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (DbUpdateException)
            //    {
            //        if (DanhMucExists(danhMuc.MaDanhMuc))
            //        {
            //            return Conflict();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return CreatedAtRoute("DefaultApi", new { id = danhMuc.MaDanhMuc }, danhMuc);
            //}

            //// DELETE: api/DanhMucs/5
            //[ResponseType(typeof(DanhMuc))]
            //public IHttpActionResult DeleteDanhMuc(string id)
            //{
            //    DanhMuc danhMuc = db.DanhMucs.Find(id);
            //    if (danhMuc == null)
            //    {
            //        return NotFound();
            //    }

            //    db.DanhMucs.Remove(danhMuc);
            //    db.SaveChanges();

            //    return Ok(danhMuc);
            //}

            //protected override void Dispose(bool disposing)
            //{
            //    if (disposing)
            //    {
            //        db.Dispose();
            //    }
            //    base.Dispose(disposing);
            //}

            //private bool DanhMucExists(string id)
            //{
            //    return db.DanhMucs.Count(e => e.MaDanhMuc == id) > 0;
            //}
        }
}