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
using BTL_qldientu.Models;

namespace BTL_qldientu.Controllers
{
    public class adminsController : ApiController
    {
        private DBMAKETAPI db = new DBMAKETAPI();

        // GET: api/admins
        public IQueryable<admin> Getadmins()
        {
            return db.admins;
        }
        //get ten with username
        [HttpGet]
        [Route("api/admin/getname")]
        public List<admin> getTenWithUsername(string username)
        {
            List<admin> listadmin = new List<admin>();
            foreach (admin Users in db.admins)
            {
                if (Users.ad_username.Contains(username))
                {
                    listadmin.Add(Users);
                }
            }
            return listadmin;
        }

        //get ten with password
        [HttpGet]
        [Route("api/admin/getname")]
        public List<admin> getTenWithPassword(string password)
        {
            List<admin> listadmin = new List<admin>();
            foreach (admin Users in db.admins)
            {
                if (Users.ad_password.Contains(password))
                {
                    listadmin.Add(Users);
                }
            }
            return listadmin;
        }
        [HttpPost]
        [Route("api/admin/postadmin")]
        public admin postadmin(admin admin)
        {
            db.admins.Add(admin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SPExists(admin.ad_id))
                {

                }
                else
                {
                    throw;
                }
            }

            return admin;
        }


        [ResponseType(typeof(admin))]
        public IHttpActionResult PostEmployee(admin employee)
        {

            db.admins.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.ad_id }, employee);
        }

 
        /// put admin
    
    
     
        [ResponseType(typeof(void))]
        public IHttpActionResult Putadmin(string id, admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.ad_id)
            {
                return BadRequest();
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPExists(id))
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

        private bool SPExists(string id)
        {
            return db.admins.Count(e => e.ad_id == id) > 0;
        }

        //cap nhat admin
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/admin/capnhatadmin")]
        public IHttpActionResult updateadmin(string id, admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.ad_id)
            {
                return BadRequest();
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPExists(id))
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
        [HttpDelete]
        [Route("api/admin/xoaadmin")]
        public bool Deleteadmin(string id)
        {
            bool isDelete = false;
            foreach (admin item in db.admins)
            {
                if (item.ad_id.Equals(id))
                {
                    isDelete = true;
                    db.admins.Remove(item);
                }
                else
                {
                    isDelete = false;
                }

            }
            db.SaveChanges();
            return isDelete;
        }
    //    [ResponseType(typeof(admin))]
    //    public IHttpActionResult Deleteadmin(string id)
    //    {
    //        admin admin = db.admins.Find(id);
    //        if (admin == null)
    //        {
    //            return NotFound();
    //        }

    //        db.admins.Remove(admin);
    //        db.SaveChanges();

    //        return Ok(admin);
    //    }
    }
}