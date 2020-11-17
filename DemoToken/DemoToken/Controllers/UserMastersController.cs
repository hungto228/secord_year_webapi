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
using DemoToken.Models;

namespace DemoToken.Controllers
{
    public class UserMastersController : ApiController
    {
        private testtokenEntities db = new testtokenEntities();

        // GET: api/UserMasters
        public IQueryable<UserMaster> GetUserMasters()
        {
            return db.UserMasters;
        }

        // GET: api/UserMasters/5
        [ResponseType(typeof(UserMaster))]
        public IHttpActionResult GetUserMaster(int id)
        {
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return NotFound();
            }

            return Ok(userMaster);
        }

        // PUT: api/UserMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserMaster(int id, UserMaster userMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userMaster.UserID)
            {
                return BadRequest();
            }

            db.Entry(userMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMasterExists(id))
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

        // POST: api/UserMasters
        [ResponseType(typeof(UserMaster))]
        public IHttpActionResult PostUserMaster(UserMaster userMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserMasters.Add(userMaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserMasterExists(userMaster.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userMaster.UserID }, userMaster);
        }

        // DELETE: api/UserMasters/5
        [ResponseType(typeof(UserMaster))]
        public IHttpActionResult DeleteUserMaster(int id)
        {
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return NotFound();
            }

            db.UserMasters.Remove(userMaster);
            db.SaveChanges();

            return Ok(userMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserMasterExists(int id)
        {
            return db.UserMasters.Count(e => e.UserID == id) > 0;
        }
    }
}