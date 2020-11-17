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
    public class categoriesController : ApiController
    {
        private DBMAKETAPI db = new DBMAKETAPI();

        // GET: api/categories
        [HttpGet]
        [Route("api/categories")]
        public IQueryable<category> Getcategories()
        {
            return db.categories;
        }

      
        //get ten with username
        [HttpGet]
        [Route("api/categories/getname")]
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
        [Route("api/categories/getname")]
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
        [Route("api/categories/postadmin")]
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


        private bool SPExists(string id)
        {
            return db.admins.Count(e => e.ad_id == id) > 0;
        }

        //cap nhat admin
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/categories/capnhatcategory")]
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
        [Route("api/categories/xoacategory")]
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
    }
}